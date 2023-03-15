using DomainDrivenDesign.Domain;

using System.Windows.Forms;


namespace DomainDrivenDesign.UserInterface
{
    public partial class UserInterfaceStateBlue : UserControl
    {
        private IUserInterface _userInterface;

        public UserInterfaceStateBlue(IUserInterface userInterface)
        {
            InitializeComponent();

            _userInterface = userInterface;
            labelCountToRed.DataBindings.Add("Text", _userInterface.SystemValues, nameof(_userInterface.SystemValues.CountToRedState));
        }

        private void ClickToRedState(object sender, System.EventArgs e)
        {
            _userInterface.ReflectUserInterfaceEvent(SystemCommand.BlueState_ProceedToRedState);
            return;
        }

        private void ClickFinish(object sender, System.EventArgs e)
        {
            _userInterface.ReflectUserInterfaceEvent(SystemCommand.BlueState_FinishSystem);
            return;
        }
    }
}