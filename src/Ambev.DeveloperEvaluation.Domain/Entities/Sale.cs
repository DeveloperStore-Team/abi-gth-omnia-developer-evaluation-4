using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sales transaction in the system.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    /// Unique sale number.
    /// </summary>
    public string? SaleNumber { get; set; }

    public Sale()
    {
        SaleDate = DateTime.Now.ToUniversalTime();
    }

    /// <summary>
    /// Date of the sale.
    /// </summary>
    public DateTime SaleDate { get; set; }
 
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

    public decimal Discounts => Items.Sum(item => item.Discount);

    /// <summary>
    /// Indicates if the sale has been canceled.
    /// </summary>
    public bool IsCanceled { get; private set; }

    /// <summary>
    /// Adds an item to the sale, applying discount rules.
    /// </summary>
    public void AddItem(SaleItem item)
    {
        if (item.Quantity > 20)
            throw new InvalidOperationException("Não é possível vender mais de 20 itens idênticos.");

        var existingItem = Items.FirstOrDefault(i => i.Id == item.Id && !IsCanceled);

        if (existingItem != null)
        {
            int newQuantity = existingItem.Quantity + item.Quantity;
            if (newQuantity > 20)
                throw new InvalidOperationException("A soma dos itens não pode exceSder 20 unidades.");

            existingItem.UpdateQuantity(newQuantity);
        }
        else
        {
            Items.Add(item);
        }
    }

    public void ClearItems()
        => Items.Clear();

    public void UpdateItems(List<SaleItem> updatedItems)
    {
        foreach (var updated in updatedItems)
        {
            if (!Items.Exists(item => item.Id == updated.Id))
            {
                AddItem(updated);
            }
            else
            {
                SaleItem item = Items.FirstOrDefault(item => item.Id == updated.Id);

                if (item != null)
                {
                    item.Price = updated.Price;
                    item.UpdateQuantity(updated.Quantity);
                }
            }
        }
    }

    /// <summary>
    /// Cancels the sale.
    /// </summary>
    public void Cancel()
    {
        IsCanceled = true;
    }

    /// <summary>
    /// Cancels a specific sale item.
    /// </summary>
    public void CancelItem(int saleItemId)
    {
        if (!Items.Exists(item => item.Id == saleItemId))
            throw new KeyNotFoundException("O item informado não está incluso nesta venda.");

        Items.Find(item => item.Id == saleItemId)?.Cancel();

        if (Items.All(item => item.IsCanceled))
            Cancel();
    }

    /// <summary>
    /// Reverses the cancelation of the sale.
    /// </summary>
    public void Reactivate()
    {
        IsCanceled = false;
    }
}
