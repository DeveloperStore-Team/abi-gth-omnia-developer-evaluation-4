using System;
using System.Collections.Generic;

namespace SalesEventMessaging.Events
{
    public class SaleCreatedEvent
    {
        public Guid SaleId { get; set; }
        public string SaleNumber { get; set; }
        public DateTime Date { get; set; }
        public string Consumer { get; set; }
        public string Agency { get; set; }
        public List<SaleItemEvent> Items { get; set; }
        public decimal TotalValue { get; set; }
        public decimal Discounts { get; set; }
    }

    public class SaleItemEvent
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalValue { get; set; }
    }
}
