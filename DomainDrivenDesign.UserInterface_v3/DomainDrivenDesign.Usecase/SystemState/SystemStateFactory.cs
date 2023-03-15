using DomainDrivenDesign.Domain;

using System;


namespace DomainDrivenDesign.Usecase
{
    internal static class SystemStateFactory
    {
        public static ISystemState GenerateState(SystemState systemState, ISampleSystemValues systemValues)
        {
            switch (systemState)
            {
                case SystemState.InitialState:
                    return new SystemStateInitial(systemValues);

                case SystemState.BlueState:
                    return new SystemStateBlue(systemValues);

                case SystemState.RedState:
                    return new SystemStateRed(systemValues);

                case SystemState.FinalState:
                    return new SystemStateFinal(systemValues);

                default:
                    throw new Exception("Unknown State");
            }
        }
    }
}
