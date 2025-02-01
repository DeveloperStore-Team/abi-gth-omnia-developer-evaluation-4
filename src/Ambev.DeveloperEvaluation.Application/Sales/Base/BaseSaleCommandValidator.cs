namespace Ambev.DeveloperEvaluation.Application.Sales;

using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

/// <summary>
/// Base validator for CreateSaleCommand and UpdateSaleCommand.
/// </summary>
public abstract class BaseSaleCommandValidator<T> : AbstractValidator<T> where T : Sale
{
    public BaseSaleCommandValidator()
    {
        RuleFor(sale => sale.Consumer).NotEmpty();
        RuleFor(sale => sale.Agency).NotEmpty();
        RuleForEach(sale => sale.Items).SetValidator(new ItemSaleDtoValidator());
    }
}

public class ItemSaleDtoValidator : AbstractValidator<SaleItem>
{
    public ItemSaleDtoValidator()
    {
        RuleFor(item => item.Product).NotEmpty();
        RuleFor(item => item.Quantity).GreaterThan(0).LessThanOrEqualTo(20);
        RuleFor(item => item.Price).GreaterThan(0);
    }
}
