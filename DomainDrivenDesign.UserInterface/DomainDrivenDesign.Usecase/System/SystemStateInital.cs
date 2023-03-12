using DomainDrivenDesign.Domain;

using System;
using System.Threading;


namespace DomainDrivenDesign.Usecase
{
    public class SystemStateInital : ISystemState
    {
        public SystemState ExecuteState(ExecuteStateCommand command)
        {
            if (command == ExecuteStateCommand.SystemStateInitial_Command)
            {
                Thread.Sleep(5000);
                return SystemState.SystemStateRed;
            } else
            {
                throw new Exception("Unknown Command");
            }
        }

        public UserInterfaceState CheckUserInterfaceState()
        {
            return UserInterfaceState.UserInterfaceStateInitial;
        }
    }
}
