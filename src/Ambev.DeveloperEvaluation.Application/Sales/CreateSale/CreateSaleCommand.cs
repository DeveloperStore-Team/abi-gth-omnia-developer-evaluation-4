using Ambev.DeveloperEvaluation.Domain.Application.Sale;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>, ISaleCommand
{
    
    public SaleNumber SaleNumber { get; private set; }
    public string Consumer { get; set; } = string.Empty;
    public string Agency { get; set; } = string.Empty;
    public List<ISaleItemCommand> Items { get; set; } = new();
}

public class ItemSaleCommand : ISaleItemCommand
{
    public string Product { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }

}
