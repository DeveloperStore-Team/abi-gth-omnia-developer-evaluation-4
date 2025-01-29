using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Application.Sale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Profile for mapping between Application and API CreateSale responses
/// </summary>
public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale feature
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleRequest, CreateSaleCommand>();
        CreateMap<ItemSaleRequest, ItemSaleCommand>();

        CreateMap<ItemSaleRequest, ISaleItemCommand>()
            .ConstructUsing(src => new ItemSaleCommand
            {
                Product = src.Product,
                Quantity = src.Quantity,
                Price = src.Price
            });

        CreateMap<ItemSaleCommand, ISaleItemCommand>()
            .ConstructUsing(src => new ItemSaleCommand
            {
                Product = src.Product,
                Quantity = src.Quantity,
                Price = src.Price
            });


        CreateMap<CreateSaleRequest, CreateSaleCommand>();
        CreateMap<CreateSaleResult, CreateSaleResponse>();
    }
}
