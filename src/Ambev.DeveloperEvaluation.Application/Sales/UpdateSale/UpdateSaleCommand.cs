using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Command for updating an existing sale.
/// </summary>
public class UpdateSaleCommand : IRequest<UpdateSaleResult>
{
    public string SaleNumber { get; set; } = string.Empty;
    public string Consumer { get; set; } = string.Empty;
    public string Agency { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public List<SaleItem> Items { get; set; } = new();
}