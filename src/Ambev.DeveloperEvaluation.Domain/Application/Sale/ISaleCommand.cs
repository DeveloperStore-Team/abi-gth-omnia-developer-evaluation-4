namespace Ambev.DeveloperEvaluation.Domain.Application.Sale
{
    public interface ISaleCommand
    {
        string Consumer { get; }
        string Agency { get; }
        public List<ISaleItemCommand> Items { get; set; }
    }
}
