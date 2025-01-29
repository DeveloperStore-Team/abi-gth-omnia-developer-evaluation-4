using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Vendas.GetVenda;

/// <summary>
/// Handler for processing GetVendaCommand requests
/// </summary>
public class GetVendaHandler : IRequestHandler<GetVendaCommand, GetVendaResult>
{
    private readonly IVendaRepository _vendaRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetVendaHandler
    /// </summary>
    /// <param name="vendaRepository">The venda repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetVendaCommand</param>
    public GetVendaHandler(
        IVendaRepository vendaRepository,
        IMapper mapper)
    {
        _vendaRepository = vendaRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetVendaCommand request
    /// </summary>
    /// <param name="request">The GetVenda command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The venda details if found</returns>
    public async Task<GetVendaResult> Handle(GetVendaCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetVendaValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var venda = await _vendaRepository.GetByIdAsync(request.Id, cancellationToken);
        if (venda == null)
            throw new KeyNotFoundException($"Venda with ID {request.Id} not found");

        return _mapper.Map<GetVendaResult>(venda);
    }
}
