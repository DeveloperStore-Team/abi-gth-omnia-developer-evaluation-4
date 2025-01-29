namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.UpdateVenda;

/// <summary>
/// API response model for UpdateVenda operation
/// </summary>
public class UpdateVendaResponse
{
    public Guid Id { get; set; }
    public string NumeroVenda { get; set; } = string.Empty;
    public string Cliente { get; set; } = string.Empty;
    public decimal ValorTotal { get; set; }
}