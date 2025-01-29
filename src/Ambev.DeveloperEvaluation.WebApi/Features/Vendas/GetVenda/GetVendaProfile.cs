using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.Vendas.GetVenda;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.GetVenda;

/// <summary>
/// Profile for mapping GetVenda feature requests to commands
/// </summary>
public class GetVendaProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetVenda feature
    /// </summary>
    public GetVendaProfile()
    {
        CreateMap<Guid, Application.Vendas.GetVenda.GetVendaCommand>()
        .ConstructUsing(id => new Application.Vendas.GetVenda.GetVendaCommand(id));


        CreateMap<GetVendaResult, GetVendaResponse>();
    }
}
