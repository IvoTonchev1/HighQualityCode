namespace AirConditioningTestingSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Data;
    using Exceptions;
    using Models;

    public class CommandController
    {
        private AirConditionerDatabase database;

        public CommandController(AirConditionerDatabase database)
        {
            this.database = new AirConditionerDatabase();
        }

        public void ExecuteCommand(string command, string[] parameters)
        {
            try
            {
                switch (command)
                {
                    case "RegisterStationaryAirConditioner":
                        this.ValidateParametersCount(parameters, 4);
                        this.RegisterStationaryAirConditioner(
                            parameters[0],
                            parameters[1],
                            parameters[2],
                            int.Parse(parameters[3]));
                        break;
                    case "RegisterCarAirConditioner":
                        this.ValidateParametersCount(parameters, 3);
                        this.RegisterCarAirConditioner(
                            parameters[0],
                            parameters[1],
                            int.Parse(parameters[2]));
                        break;
                    case "RegisterPlaneAirConditioner":
                        this.ValidateParametersCount(parameters, 4);
                        this.RegisterPlaneAirConditioner(
                            parameters[0],
                           parameters[1],
                            int.Parse(parameters[2]),
                            int.Parse(parameters[3]));
                        break;
                    case "TestAirConditioner":
                        this.ValidateParametersCount(parameters, 2);
                        this.TestAirConditioner(
                            parameters[0],
                            parameters[1]);
                        break;
                    case "FindAirConditioner":
                        this.ValidateParametersCount(parameters, 2);
                        this.FindAirConditioner(
                            parameters[0],
                            parameters[1]);
                        break;
                    case "FindReport":
                        this.ValidateParametersCount(parameters, 2);
                        this.FindReport(
                            parameters[0],
                            parameters[1]);
                        break;
                    case "Status":
                        this.ValidateParametersCount(parameters, 0);
                        this.Status();
                        break;
                    case "FindAllReportsByManufacturer":
                        this.FindAllReportsByManufacturer(parameters[0]);
                        break;
                    default:
                        throw new IndexOutOfRangeException(Constants.InvalidCommandMessage);
                }
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException(Constants.InvalidCommandMessage, ex.InnerException);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidOperationException(Constants.InvalidCommandMessage, ex.InnerException);
            }
            catch (NonExistantEntryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DuplicateEntryException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RegisterStationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            AirConditioner airConditioner = new StationaryAirConditioner(manufacturer, model, energyEfficiencyRating, powerUsage);
            this.database.AddAirConditioner(airConditioner);
            string result = string.Format(Constants.SuccessfullRegister, airConditioner.Model, airConditioner.Manufacturer);
            Console.WriteLine(result);
        }

        public void RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            AirConditioner airConditioner = new CarAirConditioner(manufacturer, model, volumeCoverage);
            this.database.AddAirConditioner(airConditioner);
            string result = string.Format(Constants.SuccessfullRegister, airConditioner.Model, airConditioner.Manufacturer);
            Console.WriteLine(result);
        }

        /// <summary>
        /// Registers PlaneAirConditioner in the System
        /// </summary>
        /// <param name="manufacturer">Input parameter for manufacturer name</param>
        /// <param name="model">Input parameter for model name</param>
        /// <param name="volumeCoverage">Input parameter for Volume Coverage of the AC</param>
        /// <param name="electricityUsed">Input parameter for Electricity Used by the AC</param>
        public void RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, int electricityUsed)
        {
            AirConditioner airConditioner = new PlaneAirConditioner(manufacturer, model, volumeCoverage, electricityUsed);
            this.database.AddAirConditioner(airConditioner);
            string result = string.Format(Constants.SuccessfullRegister, airConditioner.Model, airConditioner.Manufacturer);
            Console.WriteLine(result);
        }

        public void TestAirConditioner(string manufacturer, string model)
        {
            AirConditioner airConditioner = this.database.GetAirConditioner(manufacturer, model);
            var mark = airConditioner.Test();
            this.database.AddReport(new Report(airConditioner.Manufacturer, airConditioner.Model, mark));
            string result = string.Format(Constants.SuccessfullTest, model, manufacturer);
            Console.WriteLine(result);
        }

        /// <summary>
        /// Method for finding (by given manufacturer name and model name) and displaying info about a certain AC
        /// </summary>
        /// <param name="manufacturer">Input parameter for manufacturer name</param>
        /// <param name="model">Input parameter for model name</param>
        public void FindAirConditioner(string manufacturer, string model)
        {
            AirConditioner airConditioner = this.database.GetAirConditioner(manufacturer, model);
            Console.WriteLine(airConditioner.ToString());
        }

        public void FindReport(string manufacturer, string model)
        {
            Report report = this.database.GetReport(manufacturer, model);
            Console.WriteLine(report.ToString());
        }

        public void FindAllReportsByManufacturer(string manufacturer)
        {
            List<Report> reports = this.database.GetReportsByManufacturer(manufacturer);
            if (reports.Count == 0)
            {
                Console.WriteLine(Constants.MissingReportsMessage);
                return;
            }

            reports = reports.OrderBy(x => x.Mark).ToList();
            StringBuilder reportsPrint = new StringBuilder();
            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));
            Console.WriteLine(reportsPrint.ToString());
        }

        /// <summary>
        /// Method for displaying the percetage of tested registered ACs in the current database (rounded to the second digit)
        /// </summary>
        public void Status()
        {
            int reports = this.database.GetReportsCount();
            double airConditioners = this.database.GetAirConditionersCount();

            double percent = reports / airConditioners;
            percent = percent * 100;
            string result = string.Format(Constants.StatusMessage, percent);
            Console.WriteLine(result);
        }

        private void ValidateParametersCount(string[] parameters, int count)
        {
            if (parameters.Length != count)
            {
                throw new InvalidOperationException(Constants.InvalidCommandMessage);
            }
        }
    }
}
