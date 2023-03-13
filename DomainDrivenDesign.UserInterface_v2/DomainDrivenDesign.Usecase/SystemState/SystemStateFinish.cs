using DomainDrivenDesign.Domain;

using System;
using System.Threading;


namespace DomainDrivenDesign.Usecase
{
    internal class SystemStateFinish : ISystemState
    {
        private SystemValues _systemValues;

        public SystemStateFinish(SystemValues systemValues)
        {
            _systemValues = systemValues;
        }

        public SystemState ExecuteCommand(SystemCommand command)
        {
            throw new Exception("No implementation. Should not be called.");
        }
    }
}
