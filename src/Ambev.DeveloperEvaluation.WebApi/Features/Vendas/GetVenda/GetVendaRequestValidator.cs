using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.GetVenda;

/// <summary>
/// Validator for GetVendaRequest
/// </summary>
public class GetVendaRequestValidator : AbstractValidator<GetVendaRequest>
{
    /// <summary>
    /// Initializes validation rules for GetVendaRequest
    /// </summary>
    public GetVendaRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Venda ID is required");
    }
}
