using DomainDrivenDesign.Usecase;

using System.Windows.Forms;
using System.Threading.Tasks;


namespace DomainDrivenDesign.UserInterface
{
    public partial class UserInterfaceStateFinish : UserControl
    {
        private IDispatcher _dispatcher;

        public UserInterfaceStateFinish(IDispatcher dispatcher)
        {
            InitializeComponent();

            _dispatcher = dispatcher;
        }
    }
}
