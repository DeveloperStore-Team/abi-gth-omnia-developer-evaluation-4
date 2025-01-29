namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.GetVenda;

/// <summary>
/// Request model for getting a venda by ID
/// </summary>
public class GetVendaRequest
{
    /// <summary>
    /// The unique identifier of the venda to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
