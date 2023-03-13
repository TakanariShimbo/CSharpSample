using DomainDrivenDesign.Domain;
using DomainDrivenDesign.Usecase;

using System.Windows.Forms;


namespace DomainDrivenDesign.UserInterface
{
    public partial class UserInterfaceStateBlue : UserControl
    {
        private IViewModel _viewModel;

        public UserInterfaceStateBlue(IViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
        }

        private void ClickToRedState(object sender, System.EventArgs e)
        {
            _viewModel.Dispatch_FromUserInterfaceToSystem(SystemCommand.ToRedState);
            return;
        }

        private void ClickFinish(object sender, System.EventArgs e)
        {
            _viewModel.Dispatch_FromUserInterfaceToSystem(SystemCommand.Finish);
            return;
        }
    }
}