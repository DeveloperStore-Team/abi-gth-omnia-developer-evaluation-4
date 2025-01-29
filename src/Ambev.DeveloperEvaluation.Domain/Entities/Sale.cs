using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sales transaction in the system.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    /// Unique sale number.
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    /// Date of the sale.
    /// </summary>
    public DateTime DataSale { get; set; }

    /// <summary>
    /// Name of the customer.
    /// </summary>
    public string Consumer { get; set; } = string.Empty;

    /// <summary>
    /// Name of the agency where the sale occurred.
    /// </summary>
    public string Agency { get; set; } = string.Empty;

    /// <summary>
    /// List of items in the sale.
    /// </summary>
    public List<SaleItem> Items { get; set; } = new List<SaleItem>();

    /// <summary>
    /// Total value of the sale.
    /// </summary>
    public decimal TotalValue => Items.Sum(item => item.TotalValue);

    /// <summary>
    /// Indicates if the sale has been canceled.
    /// </summary>
    public bool IsCanceled { get; private set; }

    /// <summary>
    /// Cancels the sale.
    /// </summary>
    public void Cancel()
    {
        IsCanceled = true;
    }

    /// <summary>
    /// Reverses the cancelation of the sale.
    /// </summary>
    public void Reactivate()
    {
        IsCanceled = false;
    }
}

