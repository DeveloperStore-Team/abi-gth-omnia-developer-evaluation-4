using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.CreateVenda;
using FluentValidation;

public class CreateVendaRequestValidator : AbstractValidator<CreateVendaRequest>
{
    public CreateVendaRequestValidator()
    {
        RuleFor(venda => venda.NumeroVenda)
            .NotEmpty()
            .WithMessage("O número da venda é obrigatório.")
            .Length(3, 50)
            .WithMessage("O número da venda deve ter entre 3 e 50 caracteres.");

        RuleFor(venda => venda.Cliente)
            .NotEmpty()
            .WithMessage("O cliente é obrigatório.");

        RuleFor(venda => venda.Agencia)
            .NotEmpty()
            .WithMessage("A agência é obrigatória.");

        RuleFor(venda => venda.DataVenda)
            .NotEmpty()
            .WithMessage("A data da venda é obrigatória.")
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("A data da venda não pode ser no futuro.");

        RuleForEach(venda => venda.Itens)
            .SetValidator(new ItemVendaRequestValidator());
    }
}

public class ItemVendaRequestValidator : AbstractValidator<ItemVendaRequest>
{
    public ItemVendaRequestValidator()
    {
        RuleFor(item => item.Produto)
            .NotEmpty()
            .WithMessage("O produto é obrigatório.");

        RuleFor(item => item.Quantidade)
            .GreaterThan(0)
            .WithMessage("A quantidade deve ser maior que 0.")
            .LessThanOrEqualTo(20)
            .WithMessage("A quantidade não pode exceder 20 unidades.");

        RuleFor(item => item.PrecoUnitario)
            .GreaterThan(0)
            .WithMessage("O preço unitário deve ser maior que 0.");

        RuleFor(item => item.Desconto)
            .Must((item, desconto) => ValidarDesconto(item, desconto))
            .WithMessage("O desconto aplicado é inválido para a quantidade informada.");

        RuleFor(item => item.ValorTotal)
            .Must((item, valorTotal) => ValidarValorTotal(item, valorTotal))
            .WithMessage("O valor total do item está incorreto.");
    }

    private bool ValidarDesconto(ItemVendaRequest item, decimal desconto)
    {
        decimal descontoEsperado = item.Quantidade switch
        {
            <= 3 => 0, // Sem desconto
            <= 9 => item.Quantidade * item.PrecoUnitario * 0.10m, // 10%
            <= 20 => item.Quantidade * item.PrecoUnitario * 0.20m, // 20%
            _ => 0
        };

        return desconto == descontoEsperado;
    }

    private bool ValidarValorTotal(ItemVendaRequest item, decimal valorTotal)
    {
        decimal descontoCalculado = item.Quantidade switch
        {
            <= 3 => 0, // Sem desconto
            <= 9 => item.Quantidade * item.PrecoUnitario * 0.10m, // 10%
            <= 20 => item.Quantidade * item.PrecoUnitario * 0.20m, // 20%
            _ => 0
        };

        return valorTotal == (item.Quantidade * item.PrecoUnitario) - descontoCalculado;
    }
}
