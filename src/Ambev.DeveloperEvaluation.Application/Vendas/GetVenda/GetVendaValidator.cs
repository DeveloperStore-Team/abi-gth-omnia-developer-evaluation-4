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
            .NotEmpty().WithMessage("O ID da venda � obrigat�rio.")
            .NotEqual(Guid.Empty).WithMessage("O ID da venda � inv�lido.");
    }
}
