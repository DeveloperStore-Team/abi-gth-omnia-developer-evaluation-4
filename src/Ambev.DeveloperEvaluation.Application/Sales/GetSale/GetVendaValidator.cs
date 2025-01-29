using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Validator for the GetSaleCommand.
/// </summary>
public class GetSaleValidator : AbstractValidator<GetSaleCommand>
{
    public GetSaleValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("O ID da sale � obrigat�rio.")
            .NotEqual(Guid.Empty).WithMessage("O ID da sale � inv�lido.");
    }
}
