using DomainDrivenDesign.Domain;


namespace DomainDrivenDesign.Usecase
{
    public interface ISystemState
    {
        SystemState ExecuteCommand(SystemCommand command);
        UserInterfaceState QueryUserInterfaceState();
    }
}
