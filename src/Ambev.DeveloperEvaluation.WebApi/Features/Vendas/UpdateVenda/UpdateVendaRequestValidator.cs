using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.UpdateVenda;

/// <summary>
/// Validator for UpdateVendaRequest
/// </summary>
public class UpdateVendaRequestValidator : AbstractValidator<UpdateVendaRequest>
{
    public UpdateVendaRequestValidator()
    {
        RuleFor(venda => venda.Id)
            .NotEmpty()
            .WithMessage("O ID da venda é obrigatório.");

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
    }
}