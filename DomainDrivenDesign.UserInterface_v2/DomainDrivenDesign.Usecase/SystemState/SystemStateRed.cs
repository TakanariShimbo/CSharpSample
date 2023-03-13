using DomainDrivenDesign.Domain;

using System;
using System.Threading;


namespace DomainDrivenDesign.Usecase
{
    internal class SystemStateRed : ISystemState
    {
        private CancellationTokenSource _canceler;
        private CancellationToken _cancelListener;
        private SystemState _nextSystemState;
        private SystemValues _systemValues;

        public SystemStateRed(SystemValues systemValues)
        {
            _canceler = new CancellationTokenSource();
            _cancelListener = _canceler.Token;
            _nextSystemState = SystemState.Blue;
            _systemValues = systemValues;
        }

        public SystemState ExecuteCommand(SystemCommand command)
        {
            switch (command)
            {
                case SystemCommand.Start:
                    MainAction();
                    return _nextSystemState;

                case SystemCommand.Cancel:
                    CancelMainAction();
                    _nextSystemState = SystemState.Blue;
                    return SystemState.Continue;

                case SystemCommand.Finish:
                    CancelMainAction();
                    _nextSystemState = SystemState.Finish;
                    return SystemState.Continue;

                default:
                    throw new Exception("Unknown Command");
            }
        }

        private void MainAction()
        {
            if (isMainActionCanceled) return;
            Thread.Sleep(3000);
            if (isMainActionCanceled) return;
            Thread.Sleep(3000);
            if (isMainActionCanceled) return;
            Thread.Sleep(3000);
            if (isMainActionCanceled) return;
            Thread.Sleep(3000);
            if (isMainActionCanceled) return;
            Thread.Sleep(3000);
            return;
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
            return;
        }
    }
}