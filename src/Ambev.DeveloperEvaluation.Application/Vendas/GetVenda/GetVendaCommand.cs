using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Vendas.GetVenda;

/// <summary>
/// Command for retrieving a venda by their ID
/// </summary>
public record GetVendaCommand : IRequest<GetVendaResult>
{
    /// <summary>
    /// The unique identifier of the venda to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetVendaCommand
    /// </summary>
    /// <param name="id">The ID of the venda to retrieve</param>
    public GetVendaCommand(Guid id)
    {
        Id = id;
    }
}
