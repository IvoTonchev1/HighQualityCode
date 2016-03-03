namespace WinterIsComing.Core.Commands
{
    using System;
    using System.Linq;
    using Interfaces;

    public class StatusCommand : AbstractCommand
    {
        public StatusCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string unitName = commandArgs[1];

            var unit = this.Engine.Units.First(u => u.Name == unitName);

            Console.WriteLine(unit.ToString());
        }
    }
}
