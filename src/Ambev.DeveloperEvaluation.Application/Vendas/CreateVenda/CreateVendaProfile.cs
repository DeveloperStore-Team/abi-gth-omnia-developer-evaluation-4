namespace Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda;

using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Profile for mapping between Venda entity and CreateVendaResponse
/// </summary>
public class CreateVendaProfile : Profile
{
    public CreateVendaProfile()
    {
        CreateMap<CreateVendaCommand, Venda>();
        CreateMap<ItemVendaCommand, ItemVenda>();
        CreateMap<Venda, CreateVendaResult>();
    }
}

