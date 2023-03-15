using DomainDrivenDesign.Domain;

using System.Windows.Forms;


namespace DomainDrivenDesign.UserInterface
{
    public partial class UserInterfaceStateInitial : UserControl
    {
        private IUserInterface _userInterface;

        public UserInterfaceStateInitial(IUserInterface userInterface)
        {
            InitializeComponent();

            _userInterface = userInterface;
        }
    }
}
