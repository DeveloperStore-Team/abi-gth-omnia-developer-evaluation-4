namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Represents the response returned after successfully updating a sale.
/// </summary>
public class UpdateSaleResult
{
    public Guid Id { get; set; }
    public decimal TotalValue { get; set; }
}