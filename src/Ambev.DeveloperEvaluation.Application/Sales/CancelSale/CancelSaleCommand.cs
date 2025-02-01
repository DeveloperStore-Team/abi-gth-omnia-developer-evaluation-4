
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Command for deleting a sale
/// </summary>
public record CancelSaleCommand : IRequest<bool>
{
    /// <summary>
    /// The unique identifier of the sale to delete
    /// </summary>  
    public SaleNumber SaleNumber { get; }

    /// <summary>
    /// Initializes a new instance of DeleteSaleCommand
    /// </summary>
    /// <param name="id">The ID of the sale to delete</param>
    public CancelSaleCommand(SaleNumber id)
    {
        SaleNumber = id;
    }
}
