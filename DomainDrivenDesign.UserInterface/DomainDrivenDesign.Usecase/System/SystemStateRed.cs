using DomainDrivenDesign.Domain;

using System;
using System.Threading;
using System.Threading.Tasks;


namespace DomainDrivenDesign.Usecase
{
    public class SystemStateRed : ISystemState
    {
        private CancellationTokenSource _canceler;
        private CancellationToken _cancelListener;
        private SystemState _nextSystemState;

        public SystemStateRed()
        {
            _canceler = new CancellationTokenSource();
            _cancelListener = _canceler.Token;
            _nextSystemState = SystemState.Blue;
        }

        private bool isMainActionCanceled
        {
            get
            {
                return _cancelListener.IsCancellationRequested;
            }
        }

        private void CancelMainAction()
        {
            _canceler.Cancel();
        }

        public SystemState ExecuteCommand(SystemCommand command)
        {
            if (command == SystemCommand.Start)
            {
                MainAction();
                return _nextSystemState;
            }
            else if (command == SystemCommand.Cancel)
            {
                CancelMainAction();
                _nextSystemState = SystemState.Blue;
                return SystemState.Continue;
            }
            else if (command == SystemCommand.Finish)
            {
                CancelMainAction();
                _nextSystemState = SystemState.Finish;
                return SystemState.Continue;
            }
            else
            {
                throw new Exception("Unknown Command");
            }
        }

        private void MainAction()
        {
            if (isMainActionCanceled) return;
            Thread.Sleep(1000);
            if (isMainActionCanceled) return;
            Thread.Sleep(1000);
            if (isMainActionCanceled) return;
            Thread.Sleep(1000);
            if (isMainActionCanceled) return;
            Thread.Sleep(1000);
            if (isMainActionCanceled) return;
            Thread.Sleep(1000);
            return;
        }

        public UserInterfaceState QueryUserInterfaceState()
        {
            return UserInterfaceState.Red;
        }
    }
}