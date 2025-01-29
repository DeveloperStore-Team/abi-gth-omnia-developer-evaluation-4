using Ambev.DeveloperEvaluation.Domain.Application.Venda;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda;

public class CreateVendaCommand : IRequest<CreateVendaResult>, IVendaCommand
{
    public string NumeroVenda { get; set; } = string.Empty;
    public string Cliente { get; set; } = string.Empty;
    public string Agencia { get; set; } = string.Empty;
    public DateTime DataVenda { get; set; }
    public List<IItemVendaCommand> Itens { get; set; } = new();
}

public class ItemVendaCommand : IItemVendaCommand
{
    public string Produto { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }

    /// <summary>
    /// Discount applied to the product.
    /// </summary>
    public decimal Desconto { get; set; }

    /// <summary>
    /// Total value of the item (with discount).
    /// </summary>
    public decimal ValorTotal => (PrecoUnitario * Quantidade) - Desconto;

}
