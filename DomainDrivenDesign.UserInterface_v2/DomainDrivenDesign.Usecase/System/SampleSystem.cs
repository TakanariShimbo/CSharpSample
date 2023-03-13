using DomainDrivenDesign.Domain;


namespace DomainDrivenDesign.Usecase
{
    public class SampleSystem : ISystem
    {
        private SystemValues _systemValues;
        private ISystemState _systemState;

        public SampleSystem()
        {
            _systemValues = new SystemValues();
            _systemState = SystemStateFactory.GenerateState(SystemState.Start, _systemValues);
        }

        public SystemState ExecuteCommand(SystemCommand command)
        {
            SystemState systemState = _systemState.ExecuteCommand(command);
            if (systemState == SystemState.Continue)
            {
                return systemState;
            }
            _systemState = SystemStateFactory.GenerateState(systemState, _systemValues);
            return systemState;
        }
    }
}
