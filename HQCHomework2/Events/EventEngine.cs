namespace Events
{
    using System;

    public sealed class EventEngine
    {
        private static readonly EventHolder EventsHolder = EventHolder.GetInstance;
        private static readonly InputHandler InputHandler = InputHandler.GetInstance;

        private EventEngine()
        {
        }

        public static EventEngine GetInstance
        {
            get
            {
                return EventEngineImplementation.Instance;
            }
        }

        public bool ExecuteNextCommand()
        {
            string command = Console.ReadLine();

            if (string.IsNullOrEmpty(command))
            {
                throw new ArgumentNullException("command", "Command cannot be empty.");
            }

            if (command[0] == 'A')
            {
                AddEvent(command);
                return true;
            }

            if (command[0] == 'D')
            {
                DeleteEvents(command);
                return true;
            }

            if (command[0] == 'L')
            {
                ListEvents(command);
                return true;
            }

            if (command[0] == 'E')
            {
                return false;
            }

            return false;
        }

        private static void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf('|');
            DateTime date = InputHandler.GetDate(command, "ListEvents");

            string countString = command.Substring(pipeIndex + 1);
            int count = int.Parse(countString);

            EventsHolder.ListEvents(date, count);
        }

        private static void DeleteEvents(string command)
        {
            string title = command.Substring("DeleteEvents".Length + 1);

            EventsHolder.DeleteEventFromDatabases(title);
        }

        private static void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;

            InputHandler.GetEventParameters(command, "AddEvent", out date, out title, out location);

            EventsHolder.AddEventToDatabases(date, title, location);
        }

        private static class EventEngineImplementation
        {
            internal static readonly EventEngine Instance = new EventEngine();
        }
    }
}