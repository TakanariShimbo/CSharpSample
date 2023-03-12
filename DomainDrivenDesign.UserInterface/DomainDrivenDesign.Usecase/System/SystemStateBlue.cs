using DomainDrivenDesign.Domain;

using System;
using System.Threading;


namespace DomainDrivenDesign.Usecase
{
    public class SystemStateBlue : ISystemState
    {
        public SystemState ExecuteCommand(SystemCommand command)
        {
            if (command == SystemCommand.Start)
            {
                return SystemState.Continue;
            }
            else if (command == SystemCommand.ToRedState)
            {
                return SystemState.Red;
            }
            else if (command == SystemCommand.Finish)
            {
                return SystemState.Finish;
            } else
            {
                throw new Exception("Unknown Command");
            }
        }

        public UserInterfaceState QueryUserInterfaceState()
        {
            return UserInterfaceState.Blue;
        }
    }
}
