
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Vendas.DeleteVenda;

/// <summary>
/// Command for deleting a venda
/// </summary>
public record DeleteVendaCommand : IRequest<DeleteVendaResponse>
{
    /// <summary>
    /// The unique identifier of the venda to delete
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteVendaCommand
    /// </summary>
    /// <param name="id">The ID of the venda to delete</param>
    public DeleteVendaCommand(Guid id)
    {
        Id = id;
    }
}
