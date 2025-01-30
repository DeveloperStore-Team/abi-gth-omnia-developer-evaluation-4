using System;
using System.Collections.Generic;

namespace SalesEventMessaging.Events
{
    public class SaleModifiedEvent
    {
        public Guid SaleId { get; set; }
        public List<SaleItemEvent> UpdatedItems { get; set; }
        public decimal NewTotalValue { get; set; }
        public decimal NewDiscounts { get; set; }
    }
}
