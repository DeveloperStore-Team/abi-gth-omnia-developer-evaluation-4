using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;

/// <summary>
/// Request model for deleting a user
/// </summary>
public class CancelSaleRequest
{
    /// <summary>
    /// The unique identifier of the user to delete
    /// </summary>
    public SaleNumber SaleNumber { get; set; }
}
