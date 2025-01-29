namespace Ambev.DeveloperEvaluation.Application.Vendas.UpdateVenda;

/// <summary>
/// Represents the response returned after successfully updating a sale.
/// </summary>
public class UpdateVendaResult
{
    public Guid Id { get; set; }
    public decimal ValorTotal { get; set; }
}