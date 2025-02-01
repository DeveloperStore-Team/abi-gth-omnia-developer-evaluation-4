using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Validator for UpdateSaleRequest
/// </summary>
public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    public UpdateSaleRequestValidator()
    {
        RuleFor(sale => sale.SaleNumber)
            .NotEmpty()
            .WithMessage("O número da Venda é obrigatório.");

        RuleFor(sale => sale.Consumer)
            .NotEmpty()
            .WithMessage("O cliente é obrigatório.");

        RuleFor(sale => sale.Agency)
            .NotEmpty()
            .WithMessage("A agência é obrigatória.");

    }
}

