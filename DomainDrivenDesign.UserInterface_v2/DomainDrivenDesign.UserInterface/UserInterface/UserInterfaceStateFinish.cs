using DomainDrivenDesign.Usecase;

using System.Windows.Forms;


namespace DomainDrivenDesign.UserInterface
{
    public partial class UserInterfaceStateFinish : UserControl
    {
        private IViewModel _viewModel;

        public UserInterfaceStateFinish(IViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
        }
    }
}
