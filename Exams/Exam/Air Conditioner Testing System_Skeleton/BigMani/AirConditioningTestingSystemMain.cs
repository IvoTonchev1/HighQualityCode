namespace AirConditioningTestingSystem
{
    using Core;
    using Data;
    using Interfaces;
    using UI;

    public class AirConditioningTestingSystemMain
    {
        public static void Main()
        {
            IInputHandler reader = new ConsoleReader();
            IOutputWriter writer = new ConsoleWriter();
            AirConditionerDatabase database = new AirConditionerDatabase();
            var engine = new Engine(writer, reader, database);
            engine.Run();
        }
    }
}
