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
            .NotEmpty().WithMessage("O Número da venda é necessário para a busca.")
            .NotEqual(String.Empty).WithMessage("O Número da venda é necessário para a busca.");
    }
}
