namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        /// <summary>
        /// Número único da sale.
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// Consumer relacionado à sale.
        /// </summary>
        public string Consumer { get; set; } = string.Empty;

        /// <summary>
        /// Agência onde a sale foi realizada.
        /// </summary>
        public string Agency { get; set; } = string.Empty;

        /// <summary>
        /// Data da sale.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Lista de itens na sale.
        /// </summary>
        public List<ItemSaleRequest> Items { get; set; } = new();
    }

    public class ItemSaleRequest 
    {
        public string Product { get; set; } = string.Empty;
        public int Quantity { get; set; }
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
}
