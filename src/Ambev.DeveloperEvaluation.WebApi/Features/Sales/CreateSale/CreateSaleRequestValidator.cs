using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using FluentValidation;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.SaleNumber)
            .NotEmpty()
            .WithMessage("O número da venda é obrigatório.")
            .Length(3, 50)
            .WithMessage("O número da venda deve ter entre 3 e 50 caracteres.");

        RuleFor(sale => sale.Consumer)
            .NotEmpty()
            .WithMessage("O nome do cliente é obrigatório.");

        RuleFor(sale => sale.Agency)
            .NotEmpty()
            .WithMessage("O nome da agência é obrigatório.");

        RuleFor(sale => sale.SaleDate)
            .NotEmpty()
            .WithMessage("A data da venda é obrigatória.")
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("A data da venda não pode ser no futuro.");

        RuleForEach(sale => sale.Items)
            .SetValidator(new ItemSaleRequestValidator());
    }
}

public class ItemSaleRequestValidator : AbstractValidator<ItemSaleRequest>
{
    public ItemSaleRequestValidator()
    {
        RuleFor(item => item.Product)
            .NotEmpty()
            .WithMessage("O nome do produto é obrigatório.");

        RuleFor(item => item.Quantity)
            .GreaterThan(0)
            .WithMessage("A quantidade deve ser maior que 0.")
            .LessThanOrEqualTo(20)
            .WithMessage("A quantidade não pode exceder 20 unidades.");

        RuleFor(item => item.Price)
            .GreaterThan(0)
            .WithMessage("O preço unitário deve ser maior que 0.");

        RuleFor(item => item.Discount)
            .Must((item, desconto) => ValidarDesconto(item, desconto))
            .WithMessage("O desconto aplicado é inválido para a quantidade informada.");

        RuleFor(item => item.TotalValue)
            .Must((item, totalValue) => ValidarTotalValue(item, totalValue))
            .WithMessage("O valor total do item está incorreto.");
    }

    private bool ValidarDesconto(ItemSaleRequest item, decimal desconto)
    {
        decimal descontoEsperado = item.Quantity switch
        {
            <= 3 => 0, // Sem desconto
            <= 9 => item.Quantity * item.Price * 0.10m, // 10%
            <= 20 => item.Quantity * item.Price * 0.20m, // 20%
            _ => 0
        };

        return desconto == descontoEsperado;
    }

    private bool ValidarTotalValue(ItemSaleRequest item, decimal totalValue)
    {
        decimal descontoCalculado = item.Quantity switch
        {
            <= 3 => 0, // Sem desconto
            <= 9 => item.Quantity * item.Price * 0.10m, // 10%
            <= 20 => item.Quantity * item.Price * 0.20m, // 20%
            _ => 0
        };

        return totalValue == (item.Quantity * item.Price) - descontoCalculado;
    }
}
