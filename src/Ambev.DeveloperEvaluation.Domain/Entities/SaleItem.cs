namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem
    {
        public int Id { get; set; }
        public string Product { get; set; } = string.Empty;
        public int Quantity { get; private set; }
        public decimal Price { get; set; }
        public decimal Discount { get; private set; }
        public decimal TotalValue => (Price * Quantity) - Discount;
        public bool IsCanceled { get; private set; }

        public void Cancel()
        {
            IsCanceled = true;
        }

        public SaleItem(string product, int quantity, decimal price)
        {
            Product = product;
            Quantity = quantity;
            Price = price;
            RecalculateValues();
        }

        /// <summary>
        /// Updates the quantity and recalculates values.
        /// </summary>
        public void UpdateQuantity(int newQuantity)
        {
            Quantity = newQuantity;
            RecalculateValues();
        }

        /// <summary>
        /// Recalculates discount and total value.
        /// </summary>
        private void RecalculateValues()
        {
            Discount = Quantity switch
            {
                <= 3 => 0, // Sem desconto
                <= 9 => Quantity * Price * 0.10m, // 10%
                <= 20 => Quantity * Price * 0.20m, // 20%
                _ => 0
            };
        }
    }
}
