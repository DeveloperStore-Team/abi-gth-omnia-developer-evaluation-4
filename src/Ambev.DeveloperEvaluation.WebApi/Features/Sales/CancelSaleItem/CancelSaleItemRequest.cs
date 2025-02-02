using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem;

/// <summary>
/// Request model for deleting a user
/// </summary>
public class CancelSaleItemRequest
{
    /// <summary>
    /// The unique identifier of the user to delete
    /// </summary>
    public SaleNumber SaleNumber { get; set; }
    public int SaleItemId { get; set; }
}
