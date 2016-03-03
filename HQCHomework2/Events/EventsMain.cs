namespace Events
{
    internal class EventsMain
    {
        private static readonly EventEngine Engine = EventEngine.GetInstance;
        private static readonly ConsoleRenderer Renderer = ConsoleRenderer.GetInstance;

        public static void Main()
        {
            while (Engine.ExecuteNextCommand())
            {
            }

            Renderer.PrintMessages();
        }
    }
}