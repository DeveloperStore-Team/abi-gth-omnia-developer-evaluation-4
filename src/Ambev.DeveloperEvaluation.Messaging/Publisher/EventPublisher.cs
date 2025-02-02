using Ambev.DeveloperEvaluation.Messaging.Configuration;
using Ambev.DeveloperEvaluation.Messaging.Publisher.Interfaces;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Messaging.Publisher
{
    internal class EventPublisher : IEventPublisher
    {
        private readonly IBus _bus;
        private readonly ILogger<EventPublisher> _logger;
        private readonly TimeSpan _publishTimeout; 

        public EventPublisher(IBus bus, ILogger<EventPublisher> logger, MessageBrokerSettings rabbitMQSettings)
        {
            _bus = bus;
            _logger = logger;
            _publishTimeout = TimeSpan.FromSeconds(rabbitMQSettings.PublishTimeoutSeconds!.Value);
        }

        public async Task Publish<T>(T @event) where T : class
        {
            using var cts = new CancellationTokenSource();
            var timeoutTask = Task.Delay(_publishTimeout, cts.Token);

            try
            {
                _logger.LogInformation("Publicando evento: {EventType} - Dados: {@Event}", typeof(T).Name, @event);

                var publishTask = _bus.Publish(@event, cts.Token);

                var completedTask = await Task.WhenAny(publishTask, timeoutTask);

                if (completedTask == timeoutTask)
                {
                    _logger.LogError($"Tempo limite de {_publishTimeout.TotalSeconds} segundos excedido ao publicar o evento {typeof(T).Name}.");
                    return;
                }

                cts.Cancel();
                _logger.LogInformation("Evento {EventType} publicado com sucesso.", typeof(T).Name);
            }
            catch (TimeoutException tex)
            {
                _logger.LogError(tex, "Timeout ao publicar evento {EventType}.", typeof(T).Name);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao publicar evento {EventType}.", typeof(T).Name);
                throw;
            }
        }
    }
}
