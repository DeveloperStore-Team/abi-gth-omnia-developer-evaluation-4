/// <summary>
/// Represents an item in a sale.
/// </summary>
public class SaleItem
{
    public SaleItem(string product, int quantity, decimal price)
    {
        Product = product;
        Quantity = quantity;
        Price = price;
    }

    /// <summary>
    /// Product name.
    /// </summary>
    public string Product { get; set; } = string.Empty;

    /// <summary>
    /// Quantity of the product.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Unit price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Discount applied to the product.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Total value of the item (with discount).
    /// </summary>
    public decimal TotalValue => (Price * Quantity) - Discount;
}
