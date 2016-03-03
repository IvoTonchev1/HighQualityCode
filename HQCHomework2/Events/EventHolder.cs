namespace Events
{
    using System;

    public sealed class EventHolder
    {
        private static readonly MultiDictionary<string, Event> EventsByTitle = new MultiDictionary<string, Event>(true);
        private static readonly OrderedMultiDictionary<DateTime, Event> EventsByDate = new OrderedMultiDictionary<DateTime, Event>(true);

        private EventHolder()
        {
        }

        public static EventHolder GetInstance
        {
            get
            {
                return EventHolderImplementation.Instance;
            }
        }

        public void AddEventToDatabases(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            string eventTitleLowerCase = newEvent.Title.ToLowerInvariant();

            EventsByTitle.Add(eventTitleLowerCase, newEvent);
            EventsByDate.Add(newEvent.Date, newEvent);

            Messages.EventAdded();
        }

        public void DeleteEventFromDatabases(string eventTitle)
        {
            string eventTitleLowerCase = eventTitle.ToLowerInvariant();
            var eventsToDelete = EventsByTitle[eventTitleLowerCase];
            int deletedCount = eventsToDelete.Count;

            // Delete from this.eventsByDate
            foreach (Event e in eventsToDelete)
            {
                EventsByDate.Remove(e.Date, e);
            }

            // Delete from this.eventsByTitle
            EventsByTitle.Remove(eventTitleLowerCase);

            Messages.EventDeleted(deletedCount);
        }

        public void ListEvents(DateTime date, int count)
        {
            var matchedEvents = from e in EventsByDate.RangeFrom(date, true).Values select e;

            int showed = 0;

            foreach (var eventToShow in matchedEvents.TakeWhile(eventToShow => showed != count))
            {
                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }

        private static class EventHolderImplementation
        {
            internal static readonly EventHolder Instance = new EventHolder();
        }
    }
}