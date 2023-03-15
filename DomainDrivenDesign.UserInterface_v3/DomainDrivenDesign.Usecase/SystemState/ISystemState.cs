using DomainDrivenDesign.Domain;


namespace DomainDrivenDesign.Usecase
{
    internal interface ISystemState
    {
        SystemState ExecuteCommand(SystemCommand systemCommand);
    }
}
