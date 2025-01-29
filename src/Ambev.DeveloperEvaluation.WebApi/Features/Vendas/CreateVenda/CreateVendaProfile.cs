using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda;
using Ambev.DeveloperEvaluation.Domain.Application.Venda;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.CreateVenda;

/// <summary>
/// Profile for mapping between Application and API CreateVenda responses
/// </summary>
public class CreateVendaProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateVenda feature
    /// </summary>
    public CreateVendaProfile()
    {
        CreateMap<CreateVendaRequest, CreateVendaCommand>();
        CreateMap<ItemVendaRequest, ItemVendaCommand>();

        CreateMap<ItemVendaRequest, IItemVendaCommand>()
            .ConstructUsing(src => new ItemVendaCommand
            {
                Produto = src.Produto,
                Quantidade = src.Quantidade,
                PrecoUnitario = src.PrecoUnitario,
                Desconto = src.Desconto
            });

        CreateMap<ItemVendaCommand, IItemVendaCommand>()
            .ConstructUsing(src => new ItemVendaCommand
            {
                Produto = src.Produto,
                Quantidade = src.Quantidade,
                PrecoUnitario = src.PrecoUnitario,
                Desconto = src.Desconto
            });


        CreateMap<CreateVendaRequest, CreateVendaCommand>();
        CreateMap<CreateVendaResult, CreateVendaResponse>();
    }
}
