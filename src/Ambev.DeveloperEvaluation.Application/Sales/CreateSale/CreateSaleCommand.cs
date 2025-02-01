using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{    
    public SaleNumber SaleNumber { get; private set; }
    public string Consumer { get; set; } = string.Empty;
    public string Agency { get; set; } = string.Empty;
    public List<SaleItem> Items { get; set; } = new();
}

public class ItemSaleCommand
{
    public string Product { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public decimal Discount { get; set; }

    /// <summary>
    /// Total value of the item (with discount).
    /// </summary>
    public decimal TotalValue { get; set; }

}
