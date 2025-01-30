using System;

namespace SalesEventMessaging.Events
{
    public class SaleCanceledEvent
    {
        public Guid SaleId { get; set; }
        public DateTime CanceledAt { get; set; }
    }
}
