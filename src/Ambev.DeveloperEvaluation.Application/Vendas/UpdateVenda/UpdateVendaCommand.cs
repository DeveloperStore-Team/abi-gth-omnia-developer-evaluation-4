using Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda;
using Ambev.DeveloperEvaluation.Domain.Application.Venda;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Vendas.UpdateVenda;

/// <summary>
/// Command for updating an existing sale.
/// </summary>
public class UpdateVendaCommand : IRequest<UpdateVendaResult>, IVendaCommand
{
    public Guid Id { get; set; }
    public string NumeroVenda { get; set; } = string.Empty;
    public string Cliente { get; set; } = string.Empty;
    public string Agencia { get; set; } = string.Empty;
    public DateTime DataVenda { get; set; }
    public List<IItemVendaCommand> Itens { get; set; } = new();
}