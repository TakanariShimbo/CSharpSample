using DomainDrivenDesign.Domain;
using DomainDrivenDesign.Usecase;

using System.Threading.Tasks;


namespace DomainDrivenDesign.UserInterface
{
    public interface IViewModel
    {
        ISampleSystemValues SystemValues { get; }
        bool ExecuteCommandAndChangeSystemState(SystemCommand systemCommand);
        UserInterfaceState CheckNextUserInterfaceState();
    }
}
