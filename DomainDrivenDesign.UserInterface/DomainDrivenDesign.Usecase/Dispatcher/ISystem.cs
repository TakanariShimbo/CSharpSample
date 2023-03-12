using DomainDrivenDesign.Domain;


namespace DomainDrivenDesign.Usecase
{
    public interface ISystem
    {
        void ExecuteCommand(SystemCommand command);
    }
}
