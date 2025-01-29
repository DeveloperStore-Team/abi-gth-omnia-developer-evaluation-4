namespace Ambev.DeveloperEvaluation.Application.Vendas;

using Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda;
using Ambev.DeveloperEvaluation.Domain.Application.Venda;
using FluentValidation;

/// <summary>
/// Base validator for CreateVendaCommand and UpdateVendaCommand.
/// </summary>
public abstract class BaseVendaCommandValidator<T> : AbstractValidator<T> where T : IVendaCommand
{
    public BaseVendaCommandValidator()
    {
        RuleFor(venda => venda.NumeroVenda).NotEmpty().Length(3, 50);
        RuleFor(venda => venda.Cliente).NotEmpty();
        RuleFor(venda => venda.Agencia).NotEmpty();
        RuleForEach(venda => venda.Itens).SetValidator(new ItemVendaDtoValidator());
    }
}

public class ItemVendaDtoValidator : AbstractValidator<IItemVendaCommand>
{
    public ItemVendaDtoValidator()
    {
        RuleFor(item => item.Produto).NotEmpty();
        RuleFor(item => item.Quantidade).GreaterThan(0).LessThanOrEqualTo(20);
        RuleFor(item => item.PrecoUnitario).GreaterThan(0);
    }
}
