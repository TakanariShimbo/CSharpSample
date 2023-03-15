using DomainDrivenDesign.Domain;

using System.Windows.Forms;


namespace DomainDrivenDesign.UserInterface
{
    public partial class UserInterfaceStateFinal : UserControl
    {
        private IUserInterface _userInterface;

        public UserInterfaceStateFinal(IUserInterface userInterface)
        {
            InitializeComponent();

            _userInterface = userInterface;
        }
    }
}
