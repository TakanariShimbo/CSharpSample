using DomainDrivenDesign.Domain;


namespace DomainDrivenDesign.Usecase
{
    public class SampleSystem : ISystem
    {
        private ISampleSystemValues _systemValues;
        private ISystemState _systemState;
        private SystemState _currentSystemState;

        public SampleSystem(ISampleSystemValues systemValues)
        {
            _systemValues = systemValues;
            _systemState = SystemStateFactory.GenerateState(SystemState.InitialState, _systemValues);
        }

        public bool ExecuteCommandAndChangeSystemState(SystemCommand systemCommand)
        {
            SystemState nextSystemState = _systemState.ExecuteCommand(systemCommand);
            if (nextSystemState == SystemState.ContinueState)
            {
                return false;
            }

            _systemState = SystemStateFactory.GenerateState(nextSystemState, _systemValues);
            _currentSystemState = nextSystemState;
            return true;
        }

        public SystemState CurrentSystemState
        {
            get
            {
                return _currentSystemState;
            }
        }
    }
}
