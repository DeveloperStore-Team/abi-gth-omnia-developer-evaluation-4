using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Application.Sale
{
    public interface ISaleItemCommand
    {
        string Product { get; set; }
        int Quantity { get; set; }
        decimal Price { get; set; }
        
    }
}
