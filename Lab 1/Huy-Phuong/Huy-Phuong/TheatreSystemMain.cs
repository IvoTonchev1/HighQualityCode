namespace TheaterSystem
{
    using System.Globalization;
    using System.Threading;
    using Core;
    using Repositories;

    public class TheatreSystemMain
    {       
        protected static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");

            PerformanceDatabase database = new PerformanceDatabase();
            var engine = new Engine(database);
            engine.Run();          
        }
    } 
}
