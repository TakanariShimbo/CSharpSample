using DomainDrivenDesign.Usecase;
using System.Threading;


namespace DomainDrivenDesign.UserInterface
{
    public class SampleSystemValues : BindedValuesBase, ISampleSystemValues
    {
        private int _countToRedState;
        private int _progressAtRedState;
        private string _currentSystemState;

        public SampleSystemValues() : base()
        {
            CountToRedState = 0;
            ProgressAtRedState = 0;
        }

        public int CountToRedState
        {
            get
            {
                return _countToRedState;
            }
            set
            {
                SetProperty(ref _countToRedState, value);
            }
        }

        public int ProgressAtRedState 
        {
            get
            {
                return _progressAtRedState;
            }
            set
            {
                SetProperty(ref _progressAtRedState, value);
            }
        }

        public string CurrentSystemState 
        {
            get
            {
                return _currentSystemState;
            }
            set
            {
                SetProperty(ref _currentSystemState, value);
            }
        }
    }
}
