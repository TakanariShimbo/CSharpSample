using DomainDrivenDesign.Domain;


namespace DomainDrivenDesign.Usecase
{
    public interface ISampleSystemValues
    {
        int CountToRedState { get; set; }
        int ProgressAtRedState { get; set; }
        string CurrentSystemState { get; set; }
    }
}
