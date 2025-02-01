namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Profile for mapping between UpdateSaleCommand and Sale entity.
/// </summary>
public class UpdateSaleProfile : Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleCommand, Sale>();

        CreateMap<CreateSaleCommand, UpdateSaleCommand>();
        CreateMap<ItemSaleCommand, SaleItem>();
        CreateMap<Sale, UpdateSaleResult>();
    }
}