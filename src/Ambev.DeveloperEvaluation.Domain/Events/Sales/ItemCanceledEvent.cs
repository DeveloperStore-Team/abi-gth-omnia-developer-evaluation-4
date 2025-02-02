using System;

namespace SalesEventConsumer.Events
{
    public class ItemCanceledEvent
    {
        public int SaleItemId { get; set; }
        public string SaleNumber { get; set; }
        public decimal TotalValue { get; set; }
        public decimal Discounts { get; set; }
    }
}
