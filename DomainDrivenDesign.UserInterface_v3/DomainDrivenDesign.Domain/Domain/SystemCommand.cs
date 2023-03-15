

namespace DomainDrivenDesign.Domain
{
    public enum SystemCommand
    {
        AllState_StartNewState,     // fix

        // ------ ADD ------
        BlueState_ProceedToRedState,
        BlueState_FinishSystem,

        RedState_CancelMainAction,
        RedState_FinishSystem,
        // -----------------
    }
}
