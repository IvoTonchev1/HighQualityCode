namespace AirConditioningTestingSystem.Core
{
    using System;
    using Data;
    using Interfaces;

    public class Engine
    {
        private IOutputWriter writer;
        private IInputHandler reader;
        private CommandController commandController;
        private AirConditionerDatabase database;

        public Engine(IOutputWriter writer, IInputHandler reader, AirConditionerDatabase database)
        {
            this.writer = writer;
            this.reader = reader;
            this.commandController = new CommandController(database);
            this.database = database;
        }

        public void Run()
        {
            while (true)
            {
                string line = this.reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                line = line.Trim();
                try
                {
                    var command = line.Substring(0, line.IndexOf(' '));
                    var parameters = line.Substring(line.IndexOf(' ') + 1)
                        .Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    this.commandController.ExecuteCommand(command, parameters);
                }
                catch (Exception)
                {
                    this.writer.WriteLine(Constants.InvalidCommandMessage);
                }             
            }
        }
    }
}
