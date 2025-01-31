using SalesEventConsumer.Events;
using Ambev.DeveloperEvaluation.Domain.Entities;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sales
{
    public static class SaleEventFactory
    {
        public static SaleCreatedEvent GetSaleCreatedEvent(Sale sale)
        {
            return new SaleCreatedEvent
            {
                SaleId = sale.Id,
                SaleNumber = sale.SaleNumber,
                Consumer = sale.Consumer,
                Agency = sale.Agency,
                TotalValue = sale.TotalValue,
                Items = sale.Items.Select(item => new SaleItemEvent
                {
                    Product = item.Product,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    Discount = item.Discount,
                    TotalValue = item.TotalValue
                }).ToList()
            };
        }

        public static SaleModifiedEvent GetSaleModifiedEvent(Sale sale)
        {
            return new SaleModifiedEvent
            {
                SaleId = sale.Id,
                Items = sale.Items.Select(item => new SaleItemEvent
                {
                    Product = item.Product,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    Discount = item.Discount,
                    TotalValue = item.TotalValue
                }).ToList(),
                TotalValue = sale.TotalValue,
                Discounts = sale.Items.Sum(item => item.Discount)
            };
        }

        public static SaleCanceledEvent GetSaleCanceledEvent(Sale sale)
        {
            return new SaleCanceledEvent
            {
                SaleId = sale.Id,
                CanceledAt = DateTime.UtcNow
            };
        }
    }
}
