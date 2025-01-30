using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        public string Consumer { get; set; } = string.Empty;
        public string Agency { get; set; } = string.Empty;
        public List<ItemSaleRequest> Items { get; set; } = new();
    }

    public class ItemSaleRequest 
    {
        public string Product { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
