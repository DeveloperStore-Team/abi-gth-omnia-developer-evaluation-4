using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Validator for UpdateSaleRequest
/// </summary>
public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    public UpdateSaleRequestValidator()
    {
        RuleFor(sale => sale.Id)
            .NotEmpty()
            .WithMessage("O ID da sale é obrigatório.");

        RuleFor(sale => sale.SaleNumber)
            .NotEmpty()
            .WithMessage("O número da sale é obrigatório.")
            .Length(3, 50)
            .WithMessage("O número da sale deve ter entre 3 e 50 caracteres.");

        RuleFor(sale => sale.Consumer)
            .NotEmpty()
            .WithMessage("O cliente é obrigatório.");

        RuleFor(sale => sale.Agency)
            .NotEmpty()
            .WithMessage("A agência é obrigatória.");

        RuleFor(sale => sale.DataSale)
            .NotEmpty()
            .WithMessage("A data da sale é obrigatória.")
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("A data da sale não pode ser no futuro.");
    }
}