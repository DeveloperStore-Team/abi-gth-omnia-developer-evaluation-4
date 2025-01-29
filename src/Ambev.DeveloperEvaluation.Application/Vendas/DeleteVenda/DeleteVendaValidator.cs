using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Vendas.DeleteVenda;

/// <summary>
/// Validator for DeleteVendaCommand
/// </summary>
public class DeleteVendaValidator : AbstractValidator<DeleteVendaCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteVendaCommand
    /// </summary>
    public DeleteVendaValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Venda ID is required");
    }
}