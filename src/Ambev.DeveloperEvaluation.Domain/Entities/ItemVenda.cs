/// <summary>
/// Represents an item in a sale.
/// </summary>
public class ItemVenda
{
    public ItemVenda(string produto, int quantidade, decimal precoUnitario)
    {
        Produto = produto;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
    }

    /// <summary>
    /// Product name.
    /// </summary>
    public string Produto { get; set; } = string.Empty;

    /// <summary>
    /// Quantity of the product.
    /// </summary>
    public int Quantidade { get; set; }

    /// <summary>
    /// Unit price of the product.
    /// </summary>
    public decimal PrecoUnitario { get; set; }

    /// <summary>
    /// Discount applied to the product.
    /// </summary>
    public decimal Desconto { get; set; }

    /// <summary>
    /// Total value of the item (with discount).
    /// </summary>
    public decimal ValorTotal => (PrecoUnitario * Quantidade) - Desconto;
}
