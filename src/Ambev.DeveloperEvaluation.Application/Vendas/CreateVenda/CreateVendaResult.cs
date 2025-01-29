namespace Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda;

/// <summary>
/// Represents the response returned after successfully creating a new sale.
/// </summary>
public class CreateVendaResult
{
    public Guid Id { get; set; }
    public decimal ValorTotal { get; set; }
}
