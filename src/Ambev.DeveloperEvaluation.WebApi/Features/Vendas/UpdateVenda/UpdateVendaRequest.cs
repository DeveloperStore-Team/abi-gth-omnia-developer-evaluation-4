using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.CreateVenda;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.UpdateVenda;

/// <summary>
/// Request model for updating a venda
/// </summary>
public class UpdateVendaRequest
{
    public Guid Id { get; set; }
    public string NumeroVenda { get; set; } = string.Empty;
    public string Cliente { get; set; } = string.Empty;
    public string Agencia { get; set; } = string.Empty;
    public DateTime DataVenda { get; set; }
    public List<ItemVendaRequest> Itens { get; set; } = new();
}