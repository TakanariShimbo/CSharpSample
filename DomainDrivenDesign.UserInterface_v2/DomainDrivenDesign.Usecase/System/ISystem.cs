using DomainDrivenDesign.Domain;


namespace DomainDrivenDesign.Usecase
{
    public interface ISystem
    {
        SystemState ExecuteCommand(SystemCommand command);
    }
}
