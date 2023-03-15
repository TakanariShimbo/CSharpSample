using DomainDrivenDesign.Domain;
using System.Threading;
using System.Windows.Forms;


namespace DomainDrivenDesign.UserInterface
{
    public partial class UserInterfaceStateRed : UserControl
    {
        private IUserInterface _userInterface;

        public UserInterfaceStateRed(IUserInterface userInterface)
        {
            InitializeComponent();

            _userInterface = userInterface;
            progressBar.Maximum = 100;
            progressBar.DataBindings.Add("Value", _userInterface.SystemValues, nameof(_userInterface.SystemValues.ProgressAtRedState));
        }

        private void ClickCancel(object sender, System.EventArgs e)
        {
            _userInterface.ReflectUserInterfaceEvent(SystemCommand.RedState_CancelMainAction);
            return;
        }

        private void ClickFinish(object sender, System.EventArgs e)
        {
            _userInterface.ReflectUserInterfaceEvent(SystemCommand.RedState_FinishSystem);
            return;
        }
    }
}