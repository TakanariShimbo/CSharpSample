using DomainDrivenDesign.Domain;

using System;


namespace DomainDrivenDesign.Usecase
{
    public static class SystemStateFactory
    {
        static public ISystemState GenerateState(SystemState systemState)
        {
            if (systemState == SystemState.Blue)
            {
                return new SystemStateBlue();
            }
            else if (systemState == SystemState.Red)
            {
                return new SystemStateRed();
            }
            else if (systemState == SystemState.Finish)
            {
                return new SystemStateFinish();
            }
            else
            {
                throw new Exception("Unknown Command");
            }
        }
    }
}
