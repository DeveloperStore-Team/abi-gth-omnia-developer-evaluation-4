// Response da cria��o
namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.CreateVenda;

/// <summary>
/// API response model for CreateVenda operation
/// </summary>
public class CreateVendaResponse
{
    /// <summary>
    /// O identificador �nico da venda criada
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// O n�mero da venda
    /// </summary>
    public string NumeroVenda { get; set; } = string.Empty;

    /// <summary>
    /// O cliente da venda
    /// </summary>
    public string Cliente { get; set; } = string.Empty;

    /// <summary>
    /// Valor total da venda
    /// </summary>
    public decimal ValorTotal { get; set; }
}
