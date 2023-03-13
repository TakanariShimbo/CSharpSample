using DomainDrivenDesign.Domain;

using System;
using System.Threading;


namespace DomainDrivenDesign.Usecase
{
    internal class SystemStateBlue : ISystemState
    {
        private SystemValues _systemValues;

        public SystemStateBlue(SystemValues systemValues)
        {
            _systemValues = systemValues;
        }

        public SystemState ExecuteCommand(SystemCommand command)
        {
            switch (command)
            {
                case SystemCommand.Start:
                    return SystemState.Continue;

                case SystemCommand.ToRedState:
                    return SystemState.Red;

                case SystemCommand.Finish:
                    return SystemState.Finish;

                default:
                    throw new Exception("Unknown Command");
            }
        }
    }
}
