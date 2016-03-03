namespace AirConditioningSystem.Tests
{
    using AirConditioningTestingSystem.Core;
    using AirConditioningTestingSystem.Data;
    using AirConditioningTestingSystem.Exceptions;
    using AirConditioningTestingSystem.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RegisterStationaryAirConditionerTest
    {
        private AirConditionerDatabase database;
        private CommandController commandController;
        [TestInitialize]
        public void Init()
        {
            this.database = new AirConditionerDatabase();
            this.commandController = new CommandController(this.database);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateEntryException))]
        public void AlreadyRegistered_ShouldThrow()
        {
            this.database.AddAirConditioner(new StationaryAirConditioner("Toshiba", "HZ333", "B", 1232));
            this.database.AddAirConditioner(new StationaryAirConditioner("Toshiba", "HZ333", "A", 1732));
        }

        [TestMethod]
        public void AddedSuccessfully_ShouldReturnMessage()
        {
            this.commandController.RegisterStationaryAirConditioner("Toshiba", "HZ333", "B", 1232);
            string expectedOutput = "Air Conditioner model HZ333 from Toshiba registered successfully.";
        }
    }
}
