namespace TheaterSystem.Repositories
{
    using System;
    using System.Collections.Generic;
    using Exceptions;
    using Interfaces;
    using Models;

    public class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> database = new SortedDictionary<string, SortedSet<Performance>>();

        public void AddTheatre(string theatre)
        {
            if (this.database.ContainsKey(theatre))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.database[theatre] = new SortedSet<Performance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var theatres = this.database.Keys;
            return theatres;
        }

        public void AddPerformance(string theatre, string performance, DateTime dateAndTime, TimeSpan duration, decimal price)
        {
            if (!this.database.ContainsKey(theatre))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var currentTheatre = this.database[theatre];
            var endTime = dateAndTime + duration; 
            if (this.CheckDateTimeOverlapping(currentTheatre, dateAndTime, endTime))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var newPerformance = new Performance(theatre, performance, dateAndTime, duration, price); 
            currentTheatre.Add(newPerformance);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theatres = this.database.Keys;
            var result = new List<Performance>(); 
            foreach (var theatre in theatres)
            {
                var performances = this.database[theatre];
                result.AddRange(performances);
            }

            return result;
        }

        public IEnumerable<Performance> ListPerformances(string theatreName)
        {
            if (!this.database.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performances = this.database[theatreName];
            return performances;
        }

        protected internal bool CheckDateTimeOverlapping(IEnumerable<Performance> performances, DateTime startTime, DateTime endTime)
        {
            bool checkTimeOverlap = false;
            foreach (var performance in performances)
            {
                var currentStartTime = performance.DateAndTime;
                var currentEndTime = performance.DateAndTime + performance.Duration;
                checkTimeOverlap = (currentStartTime <= startTime && startTime <= currentEndTime) || 
                                       (currentStartTime <= endTime && endTime <= currentEndTime) || 
                                       (startTime <= currentStartTime && currentStartTime <= endTime) || 
                                       (startTime <= currentEndTime && currentEndTime <= endTime);
                if (checkTimeOverlap)
                {
                    break;
                }
            }

            if (checkTimeOverlap)
            {
                return true;
            }

            return false;         
        }
    }
}
