using DomainDrivenDesign.Domain;

using System;
using System.Threading;


namespace DomainDrivenDesign.Usecase
{
    public class SystemStateInitial : ISystemState
    {
        public SystemState ExecuteCommand(SystemCommand command)
        {
            if (command == SystemCommand.Start)
            {
                Thread.Sleep(2000);
                return SystemState.Blue;
            }
            else
            {
                throw new Exception("Unknown Command");
            }
        }

        public UserInterfaceState QueryUserInterfaceState()
        {
            return UserInterfaceState.Start;
        }
    }
}