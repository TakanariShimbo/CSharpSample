using DomainDrivenDesign.Domain;

using System;
using System.Threading;


namespace DomainDrivenDesign.Usecase
{
    internal class SystemStateInitial : ISystemState
    {
        private ISampleSystemValues _systemValues;

        public SystemStateInitial(ISampleSystemValues systemValues)
        {
            _systemValues = systemValues;
            SetCurrentSystemState();
        }
        
        public SystemState ExecuteCommand(SystemCommand systemCommand)
        {
            switch (systemCommand)
            {
                case SystemCommand.AllState_StartNewState:
                    Thread.Sleep(2000);
                    return SystemState.BlueState;

                default:
                    throw new Exception("Unknown Command");
            }
        }

        private void SetCurrentSystemState()
        {
            _systemValues.CurrentSystemState = GetType().Name;
        }
    }
}