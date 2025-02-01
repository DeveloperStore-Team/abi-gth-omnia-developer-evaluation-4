using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using FluentValidation;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {

        RuleFor(sale => sale.Consumer)
            .NotEmpty()
            .WithMessage("O nome do cliente é obrigatório.");

        RuleFor(sale => sale.Agency)
            .NotEmpty()
            .WithMessage("O nome da agência é obrigatório.");
    }
}