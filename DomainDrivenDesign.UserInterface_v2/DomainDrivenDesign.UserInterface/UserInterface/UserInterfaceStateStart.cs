using DomainDrivenDesign.Usecase;

using System.Windows.Forms;


namespace DomainDrivenDesign.UserInterface
{
    public partial class UserInterfaceStateStart : UserControl
    {
        private IViewModel _viewModel;

        public UserInterfaceStateStart(IViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
        }
    }
}
