namespace Ambev.DeveloperEvaluation.Application.Vendas.GetVenda;

/// <summary>
/// Result of the GetVendaCommand.
/// </summary>
public class GetVendaResult
{
    public Guid Id { get; set; }
    public string NumeroVenda { get; set; } = string.Empty;
    public DateTime DataVenda { get; set; }
    public string Cliente { get; set; } = string.Empty;
    public string Agencia { get; set; } = string.Empty;
    public List<ItemVenda> Itens { get; set; } = new List<ItemVenda>();
    public decimal ValorTotal { get; set; }
    public bool Cancelado { get; set; }
}
