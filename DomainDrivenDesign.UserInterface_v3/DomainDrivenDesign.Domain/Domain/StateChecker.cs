using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain
{
    public static class StateChecker
    {
        public static UserInterfaceState SearchForMatchingUserInterfaceState(SystemState systemState)
        {
            switch (systemState)
            {
                case SystemState.InitialState:
                    return UserInterfaceState.InitialState;

                case SystemState.FinalState:
                    return UserInterfaceState.FinalState;

                // ------ ADD ------
                case SystemState.BlueState:
                    return UserInterfaceState.BlueState;

                case SystemState.RedState:
                    return UserInterfaceState.RedState;
                // -----------------

                default:
                    throw new Exception("Unknown State");
            }
        }
    }
}
