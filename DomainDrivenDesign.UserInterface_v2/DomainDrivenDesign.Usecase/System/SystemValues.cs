

namespace DomainDrivenDesign.Usecase
{
    public class SystemValues
    {
        private int _countToRed = 0;

        public int CountToRed
        {
            get
            {
                return _countToRed;
            }
            set
            {
                _countToRed = value;
            }
        }
    }
}
