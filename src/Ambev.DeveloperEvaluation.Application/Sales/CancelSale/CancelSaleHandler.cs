using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events.Sales;
using Ambev.DeveloperEvaluation.Configuration;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Handler for processing DeleteSaleCommand requests
/// </summary>
public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, bool>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IEventPublisher _eventPublisher;

    /// <summary>
    /// Initializes a new instance of DeleteSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    public CancelSaleHandler(IEventPublisher eventPublisher, ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
        _eventPublisher = eventPublisher;
    }

    /// <summary>
    /// Handles the DeleteSaleCommand request
    /// </summary>
    /// <param name="request">The DeleteSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<bool> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new CancelSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await _saleRepository.CancelAsync(request.SaleNumber.Value, cancellationToken);

        if (sale == null)
            throw new KeyNotFoundException($"Sale with SaleNumber {request.SaleNumber.Value} is not able to cancel.");

        await _eventPublisher.Publish(SaleEventFactory.GetSaleCanceledEvent(sale));

        if (!sale.IsCanceled)
            throw new ValidationException($"Sale with SaleNumber {request.SaleNumber.Value} is not able to cancel.");

        return true;
    }
}