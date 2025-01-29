using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sales transaction in the system.
/// </summary>
public class Venda : BaseEntity
{
    /// <summary>
    /// Unique sale number.
    /// </summary>
    public string NumeroVenda { get; set; } = string.Empty;

    /// <summary>
    /// Date of the sale.
    /// </summary>
    public DateTime DataVenda { get; set; }

    /// <summary>
    /// Name of the customer.
    /// </summary>
    public string Cliente { get; set; } = string.Empty;

    /// <summary>
    /// Name of the agency where the sale occurred.
    /// </summary>
    public string Agencia { get; set; } = string.Empty;

    /// <summary>
    /// List of items in the sale.
    /// </summary>
    public List<ItemVenda> Itens { get; set; } = new List<ItemVenda>();

    /// <summary>
    /// Total value of the sale.
    /// </summary>
    public decimal ValorTotal => Itens.Sum(item => item.ValorTotal);

    /// <summary>
    /// Indicates if the sale has been canceled.
    /// </summary>
    public bool Cancelado { get; private set; }

    /// <summary>
    /// Cancels the sale.
    /// </summary>
    public void Cancelar()
    {
        Cancelado = true;
    }

    /// <summary>
    /// Reverses the cancelation of the sale.
    /// </summary>
    public void Reativar()
    {
        Cancelado = false;
    }
}

