using DomainDrivenDesign.Domain;

using System;
using System.Threading;


namespace DomainDrivenDesign.Usecase
{
    internal class SystemStateStart : ISystemState
    {
        private SystemValues _systemValues;

        public SystemStateStart(SystemValues systemValues)
        {
            _systemValues = systemValues;
        }
        
        public SystemState ExecuteCommand(SystemCommand command)
        {
            switch (command)
            {
                case SystemCommand.Start:
                    Thread.Sleep(2000);
                    return SystemState.Blue;

                default:
                    throw new Exception("Unknown Command");
            }
        }
    }
}