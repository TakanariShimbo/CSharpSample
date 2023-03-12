using DomainDrivenDesign.Domain;


namespace DomainDrivenDesign.Usecase
{
    public interface IDispatcher
    {
        void SetUserInterface(IUserInterface userInterface);
        void SetSystem(ISystem system);
        void Dispatch_FromUserInterfaceToSystem(SystemCommand systemCommand);
        void Dispatch_FromSystemToUserInterface(UserInterfaceState uiState);
    }
}
