using System;

namespace SalesEventConsumer.Events
{
    public class ItemCanceledEvent
    {
        public Guid SaleId { get; set; }
        public string Product { get; set; }
        public int CanceledQuantity { get; set; }
    }
}
