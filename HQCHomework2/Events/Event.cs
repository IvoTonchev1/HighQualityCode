namespace Events
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public int CompareTo(object other)
        {
            Event otherEvent = other as Event;

            if (otherEvent.Equals(null))
            {
                throw new ArgumentNullException("otherEvent", "OtherEvent cannot be null.");
            }

            int comparedByDate = this.Date.CompareTo(otherEvent.Date);
            int comparedByTitleTitle = string.Compare(this.Title, otherEvent.Title, StringComparison.Ordinal);
            var comparedByLocation = string.Compare(this.Location, otherEvent.Location, StringComparison.Ordinal);

            if (comparedByDate == 0)
            {
                return comparedByTitleTitle == 0 ? comparedByLocation : comparedByTitleTitle;
            }

            return comparedByDate;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));

            output.Append(" | " + this.Title);

            if (!string.IsNullOrEmpty(this.Location))
            {
                output.Append(" | " + this.Location);
            }

            return output.ToString();
        }
    }
}