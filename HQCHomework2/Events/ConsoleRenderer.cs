namespace Events
{
    using System;

    public sealed class ConsoleRenderer
    {
        private ConsoleRenderer()
        {
        }

        public static ConsoleRenderer GetInstance
        {
            get
            {
                return ConsoleRendererImplementation.Instance;
            }
        }

        public void PrintMessages()
        {
            Console.WriteLine(Messages.Output);
        }

        private static class ConsoleRendererImplementation
        {
            internal static readonly ConsoleRenderer Instance = new ConsoleRenderer();
        }
    }
}