using DomainDrivenDesign.Domain;

using System;


namespace DomainDrivenDesign.Usecase
{
    public class Dispatcher : IDispatcher
    {
        private bool _isUserInterfaceSet;
        private bool _isSystemSet;
        private IUserInterface _userInterface;
        private ISystem _system;

        public Dispatcher()
        {
            _isUserInterfaceSet = false;
            _isSystemSet = false;
        }

        public void SetUserInterface(IUserInterface userInterface)
        {
            _userInterface = userInterface;
            _isUserInterfaceSet = true;
        }

        public void SetSystem(ISystem system)
        {
            _system = system;
            _isSystemSet = true;
        }

        public void Dispatch_FromUserInterfaceToSystem(SystemCommand systemCommand)
        {
            if (!_isSystemSet)
            {
                throw new Exception("system is not set");
            }

            _system.ExecuteCommand(systemCommand);
        }

        public void Dispatch_FromSystemToUserInterface(UserInterfaceState uiState)
        {
            if (!_isUserInterfaceSet)
            {
                throw new Exception("userInterface is not set");
            }

            _userInterface.ReflectUserInterfaceState(uiState);
        }
    }
}
