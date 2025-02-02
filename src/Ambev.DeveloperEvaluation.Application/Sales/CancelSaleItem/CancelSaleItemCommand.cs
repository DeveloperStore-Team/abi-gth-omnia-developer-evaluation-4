
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

/// <summary>
/// Command for deleting a sale
/// </summary>
public class CancelSaleItemCommand : IRequest<bool>
{
    /// <summary>
    /// The unique identifier of the sale to cancel item
    /// </summary>  
    public SaleNumber SaleNumber { get; set; }


    /// <summary>
    /// The unique identifier of the sale item to cancel
    /// </summary>  
    public int SaleItemId { get; set; }

    public CancelSaleItemCommand()
    { }
}
