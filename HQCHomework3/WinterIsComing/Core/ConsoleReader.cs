namespace WinterIsComing.Core
{
    using System;
    using Interfaces;

    public class ConsoleReader : IInputReader
    {
        public string ReadNextLine()
        {
            return Console.ReadLine();
        }
    }
}
