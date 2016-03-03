namespace AirConditioningTestingSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using AirConditioningTestingSystem.Exceptions;
    using AirConditioningTestingSystem.Models;

    public class AirConditionerDatabase
    {
        public AirConditionerDatabase()
        {
            this.AirConditioners = new List<AirConditioner>();
            this.Reports = new List<Report>();
        }

        public List<AirConditioner> AirConditioners { get; private set; }

        public List<Report> Reports { get; private set; }

        public void AddAirConditioner(AirConditioner airConditioner)
        {
            if (this.AirConditioners.Any(x => x.Manufacturer == airConditioner.Manufacturer && x.Model == airConditioner.Model))
            {
                throw new DuplicateEntryException(Constants.DuplicateEntry);
            }

            this.AirConditioners.Add(airConditioner);
        }

        public AirConditioner GetAirConditioner(string manufacturer, string model)
        {
            var result = this.AirConditioners.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (result == null)
            {
                throw new NonExistantEntryException(Constants.NotExistingEntry);
            }

            return result;
        }

        public int GetAirConditionersCount()
        {
            return this.AirConditioners.Count;
        }

        public void AddReport(Report report)
        {
            if (this.Reports.Any(x => x.Manufacturer == report.Manufacturer && x.Model == report.Model))
            {
                throw new DuplicateEntryException(Constants.DuplicateEntry);
            }

            this.Reports.Add(report);
        }

        public Report GetReport(string manufacturer, string model)
        {
            var result = this.Reports.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (result == null)
            {
                throw new NonExistantEntryException(Constants.NotExistingEntry);
            }

            return result;
        }

        public int GetReportsCount()
        {
            return this.Reports.Count;
        }

        public List<Report> GetReportsByManufacturer(string manufacturer)
        {
            return this.Reports.Where(x => x.Manufacturer == manufacturer).ToList();
        }
    }
}
