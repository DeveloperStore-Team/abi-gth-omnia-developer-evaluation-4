using MassTransit;
using MassTransit.Transports;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Configuration
{
    public interface IEventPublisher
    {
        Task Publish<T>(T eventMessage) where T : class;
    }

    public class EventPublisher : IEventPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<EventPublisher> _logger;

        public EventPublisher(IPublishEndpoint publishEndpoint, ILogger<EventPublisher> logger)
        {
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        public async Task Publish<T>(T @event) where T : class
        {
            _logger.LogInformation("Publicando evento: {EventType} - Dados: {@Event}", typeof(T).Name, @event);
            await _publishEndpoint.Publish(@event);
            _logger.LogInformation("Evento {EventType} publicado com sucesso.", typeof(T).Name);
        }
    }
}
