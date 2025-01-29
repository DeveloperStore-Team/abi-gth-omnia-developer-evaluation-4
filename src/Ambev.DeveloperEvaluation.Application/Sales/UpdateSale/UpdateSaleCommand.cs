using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Application.Sale;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Command for updating an existing sale.
/// </summary>
public class UpdateSaleCommand : IRequest<UpdateSaleResult>, ISaleCommand
{
    public Guid Id { get; set; }
    public string SaleNumber { get; set; } = string.Empty;
    public string Consumer { get; set; } = string.Empty;
    public string Agency { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public List<ISaleItemCommand> Items { get; set; } = new();
}