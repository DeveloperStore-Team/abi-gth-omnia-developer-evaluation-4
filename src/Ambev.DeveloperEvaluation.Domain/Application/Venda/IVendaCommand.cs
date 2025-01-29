using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Application.Venda
{
    public interface IVendaCommand
    {
        string NumeroVenda { get; }
        string Cliente { get; }
        string Agencia { get; }
        DateTime DataVenda { get; }
        public List<IItemVendaCommand> Itens { get; set; }
    }
}
