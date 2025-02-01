using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Request model for updating a sale
/// </summary>
public class UpdateSaleRequest
{
    public string SaleNumber { get; set; } = string.Empty;
    public string Consumer { get; set; } = string.Empty;
    public string Agency { get; set; } = string.Empty;
    public List<ItemSaleRequest> Items { get; set; } = new();
}