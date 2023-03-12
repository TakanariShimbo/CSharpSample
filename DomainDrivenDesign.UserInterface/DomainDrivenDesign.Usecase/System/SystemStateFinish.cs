using DomainDrivenDesign.Domain;

using System;
using System.Threading;


namespace DomainDrivenDesign.Usecase
{
    public class SystemStateFinish : ISystemState
    {
        public SystemState ExecuteCommand(SystemCommand command)
        {
            throw new Exception("Should not be called");
        }

        public UserInterfaceState QueryUserInterfaceState()
        {
            return UserInterfaceState.Finish;
        }
    }
}
