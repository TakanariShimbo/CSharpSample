using DomainDrivenDesign.Domain;

using System;


namespace DomainDrivenDesign.Usecase
{
    internal class SystemStateBlue : ISystemState
    {
        private ISampleSystemValues _systemValues;

        public SystemStateBlue(ISampleSystemValues systemValues)
        {
            _systemValues = systemValues;
            SetCurrentSystemState();
        }

        public SystemState ExecuteCommand(SystemCommand systemCommand)
        {
            switch (systemCommand)
            {
                case SystemCommand.AllState_StartNewState:
                    return SystemState.ContinueState;

                case SystemCommand.BlueState_ProceedToRedState:
                    return SystemState.RedState;

                case SystemCommand.BlueState_FinishSystem:
                    return SystemState.FinalState;

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
