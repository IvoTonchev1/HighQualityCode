namespace TheaterSystem.Models
{
    using System;

    public class Performance : IComparable<Performance>
    {
        public Performance(string theater, string name, DateTime dateAndTime, TimeSpan duration, decimal price)
        {
            this.Theater = theater;
            this.Name = name;
            this.DateAndTime = dateAndTime;
            this.Duration = duration;
            this.Price = price;
        }

        public string Theater { get; set; }

        public string Name { get; set; }

        public DateTime DateAndTime { get; set; }

        public TimeSpan Duration { get; set; }

        protected internal decimal Price { get; set; }

        public int CompareTo(Performance otherPerformance)
        {
            int tmp = this.DateAndTime.CompareTo(otherPerformance.DateAndTime);
            return tmp;
        }

        public override string ToString()
        {
            string result = string.Format(
                                   "Performance(Theater: {0}; Name: {1}; DateAndTime: {2}, Duration: {3}, Ticket Price: {4})",
                                   this.Theater,
                                   this.Name,
                                   this.DateAndTime.ToString("dd.MM.yyyy HH:mm"),
                                   this.Duration.ToString("hh':'mm"),
                                   this.Price.ToString("f2"));
            return result;
        }
    }
}
