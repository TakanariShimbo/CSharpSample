using DomainDrivenDesign.Domain;
using DomainDrivenDesign.Usecase;

using System;
using System.Windows.Forms;


namespace DomainDrivenDesign.UserInterface
{
    public static class UserInterfaceStateFactory
    {
        public static UserControl GenerateState(UserInterfaceState uiState, IViewModel viewModel)
        {
            switch (uiState)
            {
                case UserInterfaceState.Start:
                    return new UserInterfaceStateStart(viewModel);

                case UserInterfaceState.Blue:
                    return new UserInterfaceStateBlue(viewModel);

                case UserInterfaceState.Red:
                    return new UserInterfaceStateRed(viewModel);

                case UserInterfaceState.Finish:
                    return new UserInterfaceStateFinish(viewModel);

                default:
                    throw new Exception("Unknown State");
            }
        }
    }
}
