using DomainDrivenDesign.Domain;
using DomainDrivenDesign.Usecase;


namespace DomainDrivenDesign.UserInterface
{
    public interface IUserInterface
    {
        ISampleSystemValues SystemValues { get; }
        void ReflectUserInterfaceEvent(SystemCommand systemCommand);
    }
}
