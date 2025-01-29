// Response da cria��o
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// API response model for CreateSale operation
/// </summary>
public class CreateSaleResponse
{
    /// <summary>
    /// O identificador �nico da sale criada
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// O n�mero da sale
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    /// O cliente da sale
    /// </summary>
    public string Consumer { get; set; } = string.Empty;

    /// <summary>
    /// Valor total da sale
    /// </summary>
    public decimal TotalValue { get; set; }
}
