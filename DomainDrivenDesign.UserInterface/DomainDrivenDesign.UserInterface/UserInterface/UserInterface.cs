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
        private IDispatcher _dispatcher;

        public UserInterface(IDispatcher dispatcher)
        {
            InitializeComponent();
            Shown += ShownAction;
            _dispatcher = dispatcher;
            _dispatcher.SetUserInterface(this);
        }

        private void ShownAction(object sender, EventArgs e)
        {
            PrepareUserInterfaceStates();
            ReflectUserInterfaceState(UserInterfaceState.Start);
            _dispatcher.Dispatch_FromUserInterfaceToSystem(SystemCommand.Start);
        }

        private void PrepareUserInterfaceStates()
        {
            foreach (UserInterfaceState uiState in GetValues<UserInterfaceState>())
            {
                PrepareUserInterfaceState(uiState);
            }
        }

        private void PrepareUserInterfaceState(UserInterfaceState uiState)
        {
            UserControl userControl = UserInterfaceStateFactory.GenerateState(uiState, _dispatcher);
            userControl.Location = new Point(0, 0);
            userControl.Name = GetName<UserInterfaceState>(uiState);
            userControl.Visible = false;
            Controls.Add(userControl);
        }

        public void ReflectUserInterfaceState(UserInterfaceState uiState)
        {
            Control userControl = Controls[GetName<UserInterfaceState>(uiState)];
            Invoke(new Action<Control>(ChangeUserControlTo), userControl);

            if (uiState == UserInterfaceState.Finish)
            {
                Thread.Sleep(2000);
                Invoke(new Action(Shutdown));
                return;
            }

            Task.Run(()=> {
                _dispatcher.Dispatch_FromUserInterfaceToSystem(SystemCommand.Start);
            });
        }

        private void ChangeUserControlTo(Control userControl)
        {
            Control c;
            foreach (UserInterfaceState uiState in GetValues<UserInterfaceState>())
            {
                c = Controls[GetName<UserInterfaceState>(uiState)];
                c.Visible = false;
            }

            userControl.Visible = true;
        }

        private void Shutdown()
        {
            Close();
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