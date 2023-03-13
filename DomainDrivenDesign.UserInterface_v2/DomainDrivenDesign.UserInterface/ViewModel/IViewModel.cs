using DomainDrivenDesign.Domain;


namespace DomainDrivenDesign.UserInterface
{
    public interface IViewModel
    {
        void BindUserInterface(IUserInterface userInterface);
        void Dispatch_FromUserInterfaceToSystem(SystemCommand systemCommand);
        void Dispatch_FromSystemToUserInterface(UserInterfaceState uiState);
    }
}
