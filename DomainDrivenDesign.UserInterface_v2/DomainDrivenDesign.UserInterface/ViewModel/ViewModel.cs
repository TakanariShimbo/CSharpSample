using DomainDrivenDesign.Domain;
using DomainDrivenDesign.Usecase;

using System;


namespace DomainDrivenDesign.UserInterface
{
    public class ViewModel : IViewModel
    {
        private bool _isUserInterfaceBinded;
        private IUserInterface _userInterface;
        private SampleSystem _system;

        public ViewModel(SampleSystem system)
        {
            _isUserInterfaceBinded = false;
            _system = system;
        }

        public void BindUserInterface(IUserInterface userInterface)
        {
            userInterface.SetViewModel(this);
            _userInterface = userInterface;            
            _isUserInterfaceBinded = true;
            return;
        }

        public void Dispatch_FromUserInterfaceToSystem(SystemCommand systemCommand)
        {
            SystemState systemState = _system.ExecuteCommand(systemCommand);
            if (systemState == SystemState.Continue)
            {
                return;
            }

            UserInterfaceState uiState = CheckUserInterfaceState(systemState);
            Dispatch_FromSystemToUserInterface(uiState);
        }

        public void Dispatch_FromSystemToUserInterface(UserInterfaceState uiState)
        {
            if (!_isUserInterfaceBinded)
            {
                throw new Exception("userInterface is not set");
            }

            _userInterface.ReflectUserInterfaceState(uiState);
            return;
        }

        private UserInterfaceState CheckUserInterfaceState(SystemState systemState)
        {
            switch (systemState)
            {
                case SystemState.Start:
                    return UserInterfaceState.Start;

                case SystemState.Blue:
                    return UserInterfaceState.Blue;

                case SystemState.Red:
                    return UserInterfaceState.Red;

                case SystemState.Finish:
                    return UserInterfaceState.Finish;


                default:
                    throw new Exception("Unknown State");
            }
        }
    }
}
