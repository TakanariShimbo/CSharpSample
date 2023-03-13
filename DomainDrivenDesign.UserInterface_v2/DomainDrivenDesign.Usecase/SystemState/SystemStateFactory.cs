using DomainDrivenDesign.Domain;

using System;


namespace DomainDrivenDesign.Usecase
{
    public static class SystemStateFactory
    {
        public static ISystemState GenerateState(SystemState systemState, SystemValues systemValues)
        {
            switch (systemState)
            {
                case SystemState.Start:
                    return new SystemStateStart(systemValues);

                case SystemState.Blue:
                    return new SystemStateBlue(systemValues);

                case SystemState.Red:
                    return new SystemStateRed(systemValues);

                case SystemState.Finish:
                    return new SystemStateFinish(systemValues);

                default:
                    throw new Exception("Unknown State");
            }
        }
    }
}
