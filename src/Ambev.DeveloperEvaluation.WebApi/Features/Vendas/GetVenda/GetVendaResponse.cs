namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.GetVenda;

/// <summary>
/// API response model for GetVenda operation
/// </summary>
public class GetVendaResponse
{
    /// <summary>
    /// The unique identifier of the sale
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The sale number
    /// </summary>
    public string NumeroVenda { get; set; } = string.Empty;

    /// <summary>
    /// The sale date
    /// </summary>
    public DateTime DataVenda { get; set; }

    /// <summary>
    /// The name of the client
    /// </summary>
    public string Cliente { get; set; } = string.Empty;

    /// <summary>
    /// The agency where the sale was made
    /// </summary>
    public string Agencia { get; set; } = string.Empty;

    /// <summary>
    /// List of items in the sale
    /// </summary>
    public List<ItemVenda> Itens { get; set; } = new List<ItemVenda>();

    /// <summary>
    /// The total value of the sale
    /// </summary>
    public decimal ValorTotal { get; set; }

    /// <summary>
    /// Indicates whether the sale is canceled
    /// </summary>
    public bool Cancelado { get; set; }
}
