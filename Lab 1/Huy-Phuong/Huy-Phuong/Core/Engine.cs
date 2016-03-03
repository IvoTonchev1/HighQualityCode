namespace TheaterSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;   
    using Repositories;

    public class Engine
    {
        private PerformanceDatabase performanceDatabase;

        public Engine(PerformanceDatabase performanceDatabase)
        {
            this.performanceDatabase = performanceDatabase;
        }

        public void Run()
        {
            string commandLine = Console.ReadLine();

            while (commandLine != "stop")
            {
                if (commandLine != string.Empty)
                {
                    string[] commandParts = commandLine.Split('(');
                    string command = commandParts[0];
                    string[] commandParts1 = commandLine.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] commandParams = commandParts1.Skip(1).Select(p => p.Trim()).ToArray();
                    string commandResult;
                    try
                    {
                        switch (command)
                        {
                            case "AddTheatre":
                                commandResult = this.ExecuteAddTheatreCommand(commandParams);
                                break;
                            case "PrintAllTheatres":
                                commandResult = this.ExecutePrintAllTheatresCommand();
                                break;
                            case "AddPerformance":
                                string theatreName = commandParams[0];
                                string performanceTitle = commandParams[1];
                                DateTime startDateTime = DateTime.ParseExact(commandParams[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                                TimeSpan duration = TimeSpan.Parse(commandParams[3]);
                                decimal price = decimal.Parse(commandParams[4]);
                                this.performanceDatabase.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);
                                commandResult = "Performance added";
                                break;
                            case "PrintAllPerformances":
                                commandResult = this.ExecutePrintAllPerformancesCommand();
                                break;
                            case "PrintPerformances":
                                string theatre = commandParams[0];
                                var performances = this.performanceDatabase.ListPerformances(theatre).Select(p =>
                                {
                                    string result1 = p.DateAndTime.ToString("dd.MM.yyyy HH:mm");
                                    return string.Format("({0}, {1})", p.Name, result1);
                                }).ToList();

                                if (performances.Any())
                                {
                                    commandResult = string.Join(", ", performances);
                                }
                                else
                                {
                                    commandResult = "No performances";
                                }

                                break;
                            default:
                                commandResult = "Invalid command!";
                                break;
                        }                   
                    }
                    catch (Exception ex)
                    {
                        commandResult = "Error: " + ex.Message;
                    }

                    Console.WriteLine(commandResult);
                }

                commandLine = Console.ReadLine();
            }
        }

        public string ExecuteAddTheatreCommand(string[] parameters)
        {
            string theatreName = parameters[0];       
            this.performanceDatabase.AddTheatre(theatreName);
            return "Theatre added";
        }

        public string ExecutePrintAllTheatresCommand()
        {
            var theatresCount = this.performanceDatabase.ListTheatres().Count();
            if (theatresCount > 0)
            {
                var resultTheatres = new LinkedList<string>();
                for (int i = 0; i < theatresCount; i++)
                {
                    this.performanceDatabase.ListTheatres().Skip(i).ToList().ForEach(t => resultTheatres.AddLast(t));
                    foreach (var t in this.performanceDatabase.ListTheatres().Skip(i + 1))
                    {
                        resultTheatres.Remove(t);
                    }
                }

                return string.Join(", ", resultTheatres);
            }

            return "No theatres";
        }

        public string ExecutePrintAllPerformancesCommand()
        {
            var performances = this.performanceDatabase.ListAllPerformances().ToList();
            var result = string.Empty;
            if (performances.Any())
            {
                for (int i = 0; i < performances.Count; i++)
                {
                    var sb = new StringBuilder();
                    sb.Append(result);
                    if (i > 0)
                    {
                        sb.Append(", ");
                    }

                    string result1 = performances[i].DateAndTime.ToString("dd.MM.yyyy HH:mm");
                    sb.AppendFormat("({0}, {1}, {2})", performances[i].Name, performances[i].Theater, result1);
                    result = sb + string.Empty;
                }

                return result;
            }

            return "No performances";
        }
    }
}
