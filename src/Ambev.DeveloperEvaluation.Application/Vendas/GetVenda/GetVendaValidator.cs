using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Vendas.GetVenda;

/// <summary>
/// Validator for the GetVendaCommand.
/// </summary>
public class GetVendaValidator : AbstractValidator<GetVendaCommand>
{
    public GetVendaValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("O ID da venda é obrigatório.")
            .NotEqual(Guid.Empty).WithMessage("O ID da venda é inválido.");
    }
}
