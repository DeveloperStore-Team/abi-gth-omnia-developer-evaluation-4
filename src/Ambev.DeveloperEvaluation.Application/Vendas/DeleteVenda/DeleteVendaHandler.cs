using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Vendas.DeleteVenda;

/// <summary>
/// Handler for processing DeleteVendaCommand requests
/// </summary>
public class DeleteVendaHandler : IRequestHandler<DeleteVendaCommand, DeleteVendaResponse>
{
    private readonly IVendaRepository _vendaRepository;

    /// <summary>
    /// Initializes a new instance of DeleteVendaHandler
    /// </summary>
    /// <param name="vendaRepository">The venda repository</param>
    public DeleteVendaHandler(IVendaRepository vendaRepository)
    {
        _vendaRepository = vendaRepository;
    }

    /// <summary>
    /// Handles the DeleteVendaCommand request
    /// </summary>
    /// <param name="request">The DeleteVenda command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteVendaResponse> Handle(DeleteVendaCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteVendaValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _vendaRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Venda with ID {request.Id} not found");

        return new DeleteVendaResponse { Success = true };
    }
}