using DomainDrivenDesign.Domain;
using DomainDrivenDesign.Usecase;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DomainDrivenDesign.UserInterface
{
    public partial class UserInterfaceStateRed : UserControl
    {
        private IDispatcher _dispatcher;

        public UserInterfaceStateRed(IDispatcher dispatcher)
        {
            InitializeComponent();

            _dispatcher = dispatcher;
        }

        private void ClickCancel(object sender, System.EventArgs e)
        {
            _dispatcher.Dispatch_FromUserInterfaceToSystem(SystemCommand.Cancel);
        }

        private void ClickFinish(object sender, System.EventArgs e)
        {
            _dispatcher.Dispatch_FromUserInterfaceToSystem(SystemCommand.Finish);
        }
    }
}