namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Represents the response returned after successfully creating a new sale.
/// </summary>
public class CreateSaleResult
{
    public string saleNumber { get; set; }
    public string consumer { get; set; }
    public decimal totalValue { get; set; }
}
