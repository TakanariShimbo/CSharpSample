using DomainDrivenDesign.Domain;
using DomainDrivenDesign.Usecase;

using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DomainDrivenDesign.UserInterface
{
    public partial class UserInterface : Form, IUserInterface
    {
        private bool _isClosingCorrectly;
        private IViewModel _viewModel;

        public UserInterface()
        {
            InitializeComponent();

            _isClosingCorrectly = false;
            _viewModel = new SampleViewModel();

            Shown += ShownAction;
            FormClosing += ClosingAction;

            PrepareUserInterfaceStates();
            ChangeUserInterfaceState(UserInterfaceState.InitialState, false);
        }

        private void ShownAction(object sender, EventArgs e)
        {
            Task.Run(() => {
                ReflectUserInterfaceEvent(SystemCommand.AllState_StartNewState);
            });
        }

        public ISampleSystemValues SystemValues {
            get
            {
                return _viewModel.SystemValues;
            }
        }

        public void ReflectUserInterfaceEvent(SystemCommand systemCommand)
        {
            bool isSystemStateChanged = _viewModel.ExecuteCommandAndChangeSystemState(systemCommand);
            if (!isSystemStateChanged)
            {
                return;
            }
            UserInterfaceState nextUserInterfaceState = _viewModel.CheckNextUserInterfaceState();
            ChangeUserInterfaceState(nextUserInterfaceState);
            Task taskReflectUserInterfaceEvent = Task.Run(() => {
                ReflectUserInterfaceEvent(SystemCommand.AllState_StartNewState);
            });
            if (nextUserInterfaceState == UserInterfaceState.FinalState)
            {
                taskReflectUserInterfaceEvent.Wait();
                ShutDown();
            }
            return;
        }

        private void ChangeUserInterfaceState(UserInterfaceState uiState, bool isInvoke = true)
        {
            if (isInvoke)
            {
                Invoke(new Action<string>(ChangeVisibleUserControlTo), Enum.GetName(typeof(UserInterfaceState), uiState));
            }
            else
            {
                ChangeVisibleUserControlTo(Enum.GetName(typeof(UserInterfaceState), uiState));
            }
            return;
        }

        private void ChangeVisibleUserControlTo(string targetControlName)
        {
            string currentControlName;
            Control currentControl;
            foreach (UserInterfaceState uiState in Enum.GetValues(typeof(UserInterfaceState)))
            {
                currentControlName = Enum.GetName(typeof(UserInterfaceState), uiState);
                currentControl = Controls[currentControlName];

                if (currentControlName == targetControlName)
                {
                    currentControl.Visible = true;
                }
                else
                {
                    currentControl.Visible = false;
                }
            }
            return;
        }

        private void ShutDown()
        {
            _isClosingCorrectly = true;
            Invoke(new Action(Close));
            return;
        }

        private void ClosingAction(object sender, FormClosingEventArgs e)
        {
            if (!_isClosingCorrectly)
            {
                e.Cancel = true;
            }
            return;
        }

        private void PrepareUserInterfaceStates()
        {
            foreach (UserInterfaceState uiState in Enum.GetValues(typeof(UserInterfaceState)))
            {
                PrepareUserInterfaceState(uiState);
            }
            return;
        }

        private void PrepareUserInterfaceState(UserInterfaceState uiState)
        {
            UserControl userControl = UserInterfaceStateFactory.GenerateState(uiState, this);
            userControl.Location = new Point(0, 0);
            userControl.Name = Enum.GetName(typeof(UserInterfaceState), uiState);
            userControl.Visible = false;
            Controls.Add(userControl);
            return;
        }
    }
}