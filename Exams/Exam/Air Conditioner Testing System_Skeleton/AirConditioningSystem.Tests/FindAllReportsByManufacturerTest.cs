namespace AirConditioningSystem.Tests
{
    using AirConditioningTestingSystem.Core;
    using AirConditioningTestingSystem.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FindAllReportsByManufacturerTest
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
        public void FindWithoutReports_ShouldSayNo()
        {
            this.commandController.FindAllReportsByManufacturer("Toshiba");
            string expectedOuptut = "No Reports.";
        }
    }
}
