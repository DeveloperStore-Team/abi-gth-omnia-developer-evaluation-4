namespace Ambev.DeveloperEvaluation.Application.Vendas.UpdateVenda;

using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda;

/// <summary>
/// Profile for mapping between UpdateVendaCommand and Venda entity.
/// </summary>
public class UpdateVendaProfile : Profile
{
    public UpdateVendaProfile()
    {
        CreateMap<UpdateVendaCommand, Venda>();
        CreateMap<CreateVendaCommand, UpdateVendaCommand>();
        CreateMap<ItemVendaCommand, ItemVenda>();
        CreateMap<Venda, UpdateVendaResult>();
    }
}