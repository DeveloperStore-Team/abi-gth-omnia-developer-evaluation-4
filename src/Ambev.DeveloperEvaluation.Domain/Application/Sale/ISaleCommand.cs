namespace Ambev.DeveloperEvaluation.Domain.Application.Sale
{
    public interface ISaleCommand
    {
        string SaleNumber { get; }
        string Consumer { get; }
        string Agency { get; }
        DateTime SaleDate { get; }
        public List<ISaleItemCommand> Items { get; set; }
    }
}
