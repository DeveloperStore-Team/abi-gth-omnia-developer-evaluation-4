using Ambev.DeveloperEvaluation.Configuration;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SalesEventMessaging.Configuration;
using SalesEventMessaging.Events;
using System.Text.Json;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IEventPublisher _eventPublisher;
    private readonly IMapper _mapper;

    public CreateSaleHandler
        (
            ISaleRepository saleRepository, 
            IMapper mapper,
            IEventPublisher eventPublisher
        )
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _eventPublisher = eventPublisher;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = _mapper.Map<Sale>(command);

        sale.SaleNumber = new SaleNumber().Value;

        await _saleRepository.AddAsync(sale, cancellationToken);

        var saleCreatedEvent = new SalesEventMessaging.Events.SaleCreatedEvent
        {
            SaleId = sale.Id,
            SaleNumber = sale.SaleNumber,
            Consumer = sale.Consumer,
            Agency = sale.Agency,
            TotalValue = sale.TotalValue,
            Items = sale.Items.Select(item => new SalesEventMessaging.Events.SaleItemEvent
            {
                Product = item.Product,
                Quantity = item.Quantity,
                Price = item.Price,
                Discount = item.Discount,
                TotalValue = item.TotalValue
            }).ToList()
        };

        await _eventPublisher.Publish(saleCreatedEvent);


        return _mapper.Map<CreateSaleResult>(sale);
    }
}