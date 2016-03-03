namespace TheaterSystem.Interfaces
{
    using System;
    using System.Collections.Generic;
    using TheaterSystem.Models;

    // TODO: document this interface definition
    public interface IPerformanceDatabase
    {
        // TODO: document this method, its parameters, return value, exceptions, etc.
        void AddTheatre(string theatre);

        // TODO: document this method, its parameters, return value, exceptions, etc.
        IEnumerable<string> ListTheatres();

        // TODO: document this method, its parameters, return value, exceptions, etc.
        void AddPerformance(string theatre, string performance, DateTime dateAndTime, TimeSpan duration, decimal price);

        // TODO: document this method, its parameters, return value, exceptions, etc.
        IEnumerable<Performance> ListAllPerformances();

        // TODO: document this method, its parameters, return value, exceptions, etc.
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}
