using Ambev.DeveloperEvaluation.Application.Vendas.UpdateVenda;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.UpdateVenda;

/// <summary>
/// Profile for mapping between Application and API UpdateVenda responses
/// </summary>
public class UpdateVendaProfile : Profile
{
    public UpdateVendaProfile()
    {
        CreateMap<UpdateVendaRequest, UpdateVendaCommand>();
        CreateMap<UpdateVendaResult, UpdateVendaResponse>();
    }
}