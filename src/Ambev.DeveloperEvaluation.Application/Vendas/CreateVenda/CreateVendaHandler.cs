using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda;

/// <summary>
/// Handler for processing CreateVendaCommand requests
/// </summary>
public class CreateVendaHandler : IRequestHandler<CreateVendaCommand, CreateVendaResult>
{
    private readonly IVendaRepository _vendaRepository;
    private readonly IMapper _mapper;

    public CreateVendaHandler(IVendaRepository vendaRepository, IMapper mapper)
    {
        _vendaRepository = vendaRepository;
        _mapper = mapper;
    }

    public async Task<CreateVendaResult> Handle(CreateVendaCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateVendaCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var venda = _mapper.Map<Venda>(command);

        venda.DataVenda = venda.DataVenda.ToUniversalTime();

        await _vendaRepository.AddAsync(venda, cancellationToken);

        return _mapper.Map<CreateVendaResult>(venda);
    }
}