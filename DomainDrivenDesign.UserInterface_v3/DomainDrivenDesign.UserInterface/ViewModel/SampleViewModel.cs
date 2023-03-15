using DomainDrivenDesign.Domain;
using DomainDrivenDesign.Usecase;


namespace DomainDrivenDesign.UserInterface
{
    public class SampleViewModel : IViewModel
    {
        private ISampleSystemValues _systemValues;
        private ISystem _system;

        public SampleViewModel()
        {
            _systemValues = new SampleSystemValues();
            _system = new SampleSystem(_systemValues);
        }

        public ISampleSystemValues SystemValues
        {
            get
            {
                return _systemValues;
            }
        }

        public bool ExecuteCommandAndChangeSystemState(SystemCommand systemCommand)
        {
            return _system.ExecuteCommandAndChangeSystemState(systemCommand);
        }

        public UserInterfaceState CheckNextUserInterfaceState()
        {
            SystemState systemState = CheckCurrentSystemState();
            return StateChecker.SearchForMatchingUserInterfaceState(systemState);
        }

        private SystemState CheckCurrentSystemState()
        {
            return _system.CurrentSystemState;
        }
    }
}
