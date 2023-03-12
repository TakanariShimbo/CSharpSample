using DomainDrivenDesign.Domain;
using DomainDrivenDesign.Usecase;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DomainDrivenDesign.UserInterface
{
    public partial class UserInterfaceStateBlue : UserControl
    {
        private IDispatcher _dispatcher;

        public UserInterfaceStateBlue(IDispatcher dispatcher)
        {
            InitializeComponent();

            _dispatcher = dispatcher;
        }

        private void ClickToRedState(object sender, System.EventArgs e)
        {
            _dispatcher.Dispatch_FromUserInterfaceToSystem(SystemCommand.ToRedState);
        }

        private void ClickFinish(object sender, System.EventArgs e)
        {
            _dispatcher.Dispatch_FromUserInterfaceToSystem(SystemCommand.Finish);
        }
    }
}