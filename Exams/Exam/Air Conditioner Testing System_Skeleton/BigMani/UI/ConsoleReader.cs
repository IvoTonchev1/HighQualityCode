namespace AirConditioningTestingSystem.UI
{
    using System;
    using Interfaces;

    public class ConsoleReader : IInputHandler
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
