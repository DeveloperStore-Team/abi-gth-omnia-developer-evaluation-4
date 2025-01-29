namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Profile for mapping between Sale entity and CreateSaleResponse
/// </summary>
public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, Sale>();
        CreateMap<ItemSaleCommand, SaleItem>();
        CreateMap<Sale, CreateSaleResult>();
    }
}

