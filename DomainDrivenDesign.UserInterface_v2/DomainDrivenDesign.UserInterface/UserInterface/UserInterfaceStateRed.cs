using DomainDrivenDesign.Domain;
using DomainDrivenDesign.Usecase;

using System.Windows.Forms;


namespace DomainDrivenDesign.UserInterface
{
    public partial class UserInterfaceStateRed : UserControl
    {
        private IViewModel _viewModel;

        public UserInterfaceStateRed(IViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
        }

        private void ClickCancel(object sender, System.EventArgs e)
        {
            _viewModel.Dispatch_FromUserInterfaceToSystem(SystemCommand.Cancel);
            return;
        }

        private void ClickFinish(object sender, System.EventArgs e)
        {
            _viewModel.Dispatch_FromUserInterfaceToSystem(SystemCommand.Finish);
            return;
        }
    }
}