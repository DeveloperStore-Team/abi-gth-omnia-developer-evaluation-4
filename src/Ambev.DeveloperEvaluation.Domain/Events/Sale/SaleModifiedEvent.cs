using System;
using System.Collections.Generic;

namespace SalesEventConsumer.Events
{
    public class SaleModifiedEvent
    {
        public Guid SaleId { get; set; }
        public List<SaleItemEvent> UpdatedItems { get; set; }
        public decimal NewTotalValue { get; set; }
        public decimal NewDiscounts { get; set; }
    }
}
