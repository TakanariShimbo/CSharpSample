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
        private ISampleSystemValues _systemValues;

        public SystemStateRed(ISampleSystemValues systemValues)
        {
            _canceler = new CancellationTokenSource();
            _cancelListener = _canceler.Token;
            _nextSystemState = SystemState.BlueState;
            _systemValues = systemValues;

            SetCurrentSystemState();
            CountUpToRedState();
        }

        public SystemState ExecuteCommand(SystemCommand systemCommand)
        {
            switch (systemCommand)
            {
                case SystemCommand.AllState_StartNewState:
                    MainAction();
                    return _nextSystemState;

                case SystemCommand.RedState_CancelMainAction:
                    CancelMainAction();
                    _nextSystemState = SystemState.BlueState;
                    return SystemState.ContinueState;

                case SystemCommand.RedState_FinishSystem:
                    CancelMainAction();
                    _nextSystemState = SystemState.FinalState;
                    return SystemState.ContinueState;

                default:
                    throw new Exception("Unknown Command");
            }
        }

        private void MainAction()
        {
            _systemValues.ProgressAtRedState = 0;

            if (isMainActionCanceled) return;
            Thread.Sleep(3000);
            _systemValues.ProgressAtRedState = 20;

            if (isMainActionCanceled) return;
            Thread.Sleep(3000);
            _systemValues.ProgressAtRedState = 40;

            if (isMainActionCanceled) return;
            Thread.Sleep(3000);
            _systemValues.ProgressAtRedState = 60;

            if (isMainActionCanceled) return;
            Thread.Sleep(3000);
            _systemValues.ProgressAtRedState = 80;

            if (isMainActionCanceled) return;
            Thread.Sleep(3000);
            _systemValues.ProgressAtRedState = 100;

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

        private void SetCurrentSystemState()
        {
            _systemValues.CurrentSystemState = GetType().Name;
        }

        private void CountUpToRedState()
        {
            _systemValues.CountToRedState += 1;
        }
    }
}