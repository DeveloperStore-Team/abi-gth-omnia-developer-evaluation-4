using Ambev.DeveloperEvaluation.Domain.Application.Sale;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>, ISaleCommand
{
    public string SaleNumber { get; set; } = string.Empty;
    public string Consumer { get; set; } = string.Empty;
    public string Agency { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public List<ISaleItemCommand> Items { get; set; } = new();
}

public class ItemSaleCommand : ISaleItemCommand
{
    public string Product { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    /// <summary>
    /// Discount applied to the product.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Total value of the item (with discount).
    /// </summary>
    public decimal TotalValue => (Price * Quantity) - Discount;

}
