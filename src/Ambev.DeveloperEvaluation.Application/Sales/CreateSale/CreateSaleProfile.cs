namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;


/// <summary>
/// Profile for mapping between Sale entity and CreateSaleResponse
/// </summary>
public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, Sale>()
     .ForMember(dest => dest.SaleNumber, opt => opt.MapFrom(src => src.SaleNumber.Value));


        CreateMap<ItemSaleCommand, SaleItem>();
        CreateMap<Sale, CreateSaleResult>();
    }
}

