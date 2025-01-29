namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.CreateVenda;
using Ambev.DeveloperEvaluation.Application.Vendas;
using Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda;
using Ambev.DeveloperEvaluation.Application.Vendas.GetVenda;
using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.GetVenda;
using Ambev.DeveloperEvaluation.Application.Vendas.DeleteVenda;
using Ambev.DeveloperEvaluation.Application.Vendas.UpdateVenda;
using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.UpdateVenda;

/// <summary>
/// Controller for managing sales operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class VendasController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of VendasController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public VendasController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new sale
    /// </summary>
    /// <param name="request">The sale creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateVendaResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateVenda([FromBody] CreateVendaRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateVendaRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateVendaCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateVendaResponse>
        {
            Success = true,
            Message = "Venda criada com sucesso",
            Data = _mapper.Map<CreateVendaResponse>(response)
        });
    }

    /// <summary>
    /// Retrieves a venda by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the venda</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The venda details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetVendaResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetVenda([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetVendaRequest { Id = id };
        var validator = new GetVendaRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetVendaCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetVendaResponse>
        {
            Success = true,
            Message = "Venda retrieved successfully",
            Data = _mapper.Map<GetVendaResponse>(response)
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVenda(Guid id, [FromBody] UpdateVendaRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateVendaRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<UpdateVendaCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<UpdateVendaResponse>
        {
            Success = true,
            Message = "Venda atualizada com sucesso",
            Data = _mapper.Map<UpdateVendaResponse>(response)
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVenda(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteVendaCommand(id), cancellationToken);
        return NoContent();
    }
}
