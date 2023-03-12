using DomainDrivenDesign.Domain;

using System.Threading.Tasks;


namespace DomainDrivenDesign.Usecase
{
    public class SampleSystem : ISystem
    {
        private ISystemState _systemState;
        private IDispatcher _dispatcher;

        public SampleSystem(ISystemState systemState, IDispatcher dispatcher)
        {
            _systemState = systemState;
            _dispatcher = dispatcher;
            dispatcher.SetSystem(this);
        }

        public void ExecuteCommand(SystemCommand command)
        {
            SystemState systemState = _systemState.ExecuteCommand(command);
            if (systemState == SystemState.Continue)
            {
                return;
            }

            _systemState = SystemStateFactory.GenerateState(systemState);
            UserInterfaceState uiState = _systemState.QueryUserInterfaceState();
            _dispatcher.Dispatch_FromSystemToUserInterface(uiState);
        }
    }
}
