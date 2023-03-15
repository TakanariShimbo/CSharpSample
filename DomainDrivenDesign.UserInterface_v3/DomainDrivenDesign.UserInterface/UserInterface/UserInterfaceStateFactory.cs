using DomainDrivenDesign.Domain;

using System;
using System.Windows.Forms;


namespace DomainDrivenDesign.UserInterface
{
    public static class UserInterfaceStateFactory
    {
        public static UserControl GenerateState(UserInterfaceState uiState, IUserInterface userInterface)
        {
            switch (uiState)
            {
                case UserInterfaceState.InitialState:
                    return new UserInterfaceStateInitial(userInterface);

                case UserInterfaceState.BlueState:
                    return new UserInterfaceStateBlue(userInterface);

                case UserInterfaceState.RedState:
                    return new UserInterfaceStateRed(userInterface);

                case UserInterfaceState.FinalState:
                    return new UserInterfaceStateFinal(userInterface);

                default:
                    throw new Exception("Unknown State");
            }
        }
    }
}
