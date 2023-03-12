using DomainDrivenDesign.Domain;
using DomainDrivenDesign.Usecase;

using System;
using System.Windows.Forms;


namespace DomainDrivenDesign.UserInterface
{
    public static class UserInterfaceStateFactory
    {
        static public UserControl GenerateState(UserInterfaceState uiState, IDispatcher dispatcher)
        {
            if (uiState == UserInterfaceState.Start)
            {
                return new UserInterfaceStateStart(dispatcher);
            }
            else if (uiState == UserInterfaceState.Blue)
            {
                return new UserInterfaceStateBlue(dispatcher);
            }
            else if (uiState == UserInterfaceState.Red)
            {
                return new UserInterfaceStateRed(dispatcher);
            }
            else if (uiState == UserInterfaceState.Finish)
            {
                return new UserInterfaceStateFinish(dispatcher);
            }
            else
            {
                throw new Exception("Unknown Command");
            }
        }
    }
}
