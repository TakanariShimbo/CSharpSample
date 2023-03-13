using DomainDrivenDesign.Domain;
using DomainDrivenDesign.Usecase;

using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DomainDrivenDesign.UserInterface
{
    public partial class UserInterface : Form, IUserInterface
    {
        private bool _isClosingCorrectly;
        private IViewModel _viewModel;

        public UserInterface(IViewModel viewModel)
        {
            InitializeComponent();

            Shown += ShownAction;
            FormClosing += ClosingAction;

            _isClosingCorrectly = false;
            viewModel.BindUserInterface(this);

            StartUp();
        }

        public void SetViewModel(IViewModel viewModel)
        {
            _viewModel = viewModel;
            return;
        }

        public void ReflectUserInterfaceState(UserInterfaceState uiState)
        {
            string targetControlName = GetName<UserInterfaceState>(uiState);
            Invoke(new Action<string>(ChangeUserControlTo), targetControlName);

            if (uiState == UserInterfaceState.Finish)
            {
                Thread.Sleep(2000);
                Invoke(new Action(ShutDown));
                return;
            }

            Task.Run(() =>
            {
                _viewModel.Dispatch_FromUserInterfaceToSystem(SystemCommand.Start);
            });
            return;
        }

        private void ChangeUserControlTo(string targetControlName)
        {
            string currentControlName;
            Control currentControl;
            foreach (UserInterfaceState uiState in GetValues<UserInterfaceState>())
            {
                currentControlName = GetName<UserInterfaceState>(uiState);
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

        private void PrepareUserInterfaceStates()
        {
            foreach (UserInterfaceState uiState in GetValues<UserInterfaceState>())
            {
                PrepareUserInterfaceState(uiState);
            }
            return;
        }

        private void PrepareUserInterfaceState(UserInterfaceState uiState)
        {
            UserControl userControl = UserInterfaceStateFactory.GenerateState(uiState, _viewModel);
            userControl.Location = new Point(0, 0);
            userControl.Name = GetName<UserInterfaceState>(uiState);
            userControl.Visible = false;
            Controls.Add(userControl);
            return;
        }

        private void StartUp()
        {
            Application.Run(this);
            return;
        }

        private void ShutDown()
        {
            _isClosingCorrectly = true;
            Close();
            return;
        }

        private void ShownAction(object sender, EventArgs e)
        {
            PrepareUserInterfaceStates();
            ReflectUserInterfaceState(UserInterfaceState.Start);
            return;
        }

        private void ClosingAction(object sender, FormClosingEventArgs e)
        {
            if (! _isClosingCorrectly)
            {
                e.Cancel = true;
            }

            return;
        }

        private string GetName<TEnum>(TEnum value)
        {
            return Enum.GetName(typeof(TEnum), value);
        }

        private Array GetValues<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum));
        }
    }
}