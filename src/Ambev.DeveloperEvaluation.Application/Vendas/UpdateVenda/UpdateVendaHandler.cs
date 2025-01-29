using Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Vendas.UpdateVenda;

/// <summary>
/// Handler for processing UpdateVendaCommand requests
/// </summary>
public class UpdateVendaHandler : IRequestHandler<UpdateVendaCommand, UpdateVendaResult>
{
    private readonly IVendaRepository _vendaRepository;
    private readonly IMapper _mapper;

    public UpdateVendaHandler(IVendaRepository vendaRepository, IMapper mapper)
    {
        _vendaRepository = vendaRepository;
        _mapper = mapper;
    }

    public async Task<UpdateVendaResult> Handle(UpdateVendaCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateVendaCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var venda = await _vendaRepository.GetByIdAsync(command.Id, cancellationToken);
        if (venda == null)
            throw new KeyNotFoundException("Venda não encontrada.");

        // Atualiza os campos pertinentes da venda
        var updatedVenda = _mapper.Map<Venda>(venda);

        // Atualiza os itens
        updatedVenda.Itens.Clear();
        foreach (var item in command.Itens)
        {
            venda.Itens.Add(new ItemVenda(item.Produto, item.Quantidade, item.PrecoUnitario));
        }

        await _vendaRepository.UpdateAsync(venda, cancellationToken);

        return _mapper.Map<UpdateVendaResult>(venda);
    }
}