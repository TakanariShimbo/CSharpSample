using DomainDrivenDesign.Domain;


namespace DomainDrivenDesign.Usecase
{
    public interface ISystem
    {
        bool ExecuteCommandAndChangeSystemState(SystemCommand command);
        SystemState CurrentSystemState { get; }
    }
}
