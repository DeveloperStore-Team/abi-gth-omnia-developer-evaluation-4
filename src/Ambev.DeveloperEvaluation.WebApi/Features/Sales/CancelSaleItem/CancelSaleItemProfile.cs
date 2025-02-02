using Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSaleItem;

/// <summary>
/// Profile for mapping CancelSale feature requests to commands
/// </summary>
public class CancelSaleItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CancelSale feature
    /// </summary>
    public CancelSaleItemProfile()
    {
        CreateMap<(SaleNumber saleNumber, int saleItemId), CancelSaleItemRequest>()
        .ConstructUsing(src => new CancelSaleItemRequest
        {
            SaleNumber = src.saleNumber,
            SaleItemId = src.saleItemId
        });

        CreateMap<CancelSaleItemRequest, CancelSaleItemCommand>();
    }
}
