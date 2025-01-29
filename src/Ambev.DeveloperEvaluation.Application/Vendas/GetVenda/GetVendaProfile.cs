using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Vendas.GetVenda;

/// <summary>
/// Profile for mapping Venda to GetVendaResult.
/// </summary>
public class GetVendaProfile : Profile
{
    public GetVendaProfile()
    {
        CreateMap<Venda, GetVendaResult>()
            .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.Itens));
        
    }
}
