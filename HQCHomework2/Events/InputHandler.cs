namespace Events
{
    using System;

    public sealed class InputHandler
    {
        private InputHandler()
        {
        }

        public static InputHandler GetInstance
        {
            get
            {
                return InputHandlerImplementation.Instance;
            }
        }

        public void GetEventParameters(
            string commandForExecution,
            string commandType,
            out DateTime dateAndTime,
            out string eventTitle,
            out string eventLocation)
        {
            dateAndTime = this.GetDate(commandForExecution, commandType);

            int firstPipeIndex = commandForExecution.IndexOf('|');
            int lastPipeIndex = commandForExecution.LastIndexOf('|');

            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();

                eventLocation = string.Empty;
            }
            else
            {
                eventTitle =
                    commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();

                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        public DateTime GetDate(string command, string commandType)
        {
            DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));

            return date;
        }

        private static class InputHandlerImplementation
        {
            internal static readonly InputHandler Instance = new InputHandler();
        }
    }
}