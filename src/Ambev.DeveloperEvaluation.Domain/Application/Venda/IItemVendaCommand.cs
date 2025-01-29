using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Application.Venda
{
    public interface IItemVendaCommand
    {
        string Produto { get; set; }
        int Quantidade { get; set; }
        decimal PrecoUnitario { get; set; }
        
    }
}
