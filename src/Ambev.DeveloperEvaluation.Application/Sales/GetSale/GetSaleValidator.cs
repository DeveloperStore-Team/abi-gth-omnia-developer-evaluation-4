using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Validator for the GetSaleCommand.
/// </summary>
public class GetSaleValidator : AbstractValidator<GetSaleCommand>
{
    public GetSaleValidator()
    {
        RuleFor(v => v.SaleNumber)
            .NotEmpty().WithMessage("O N�mero da venda � necess�rio para a busca.")
            .NotEqual(String.Empty).WithMessage("O N�mero da venda � necess�rio para a busca.");
    }
}
