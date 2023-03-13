using DomainDrivenDesign.Domain;


namespace DomainDrivenDesign.UserInterface
{
    public interface IUserInterface
    {
        void SetViewModel(IViewModel dispatcher);
        void ReflectUserInterfaceState(UserInterfaceState state);
    }
}
