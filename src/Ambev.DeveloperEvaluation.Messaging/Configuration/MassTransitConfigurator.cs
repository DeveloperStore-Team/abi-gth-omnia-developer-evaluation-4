using Ambev.DeveloperEvaluation.Messaging.Configuration;
using Ambev.DeveloperEvaluation.Messaging.Publisher;
using Ambev.DeveloperEvaluation.Messaging.Publisher.Interfaces;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SalesEventConsumer.Configuration
{
    public static class MassTransitConfigurator
    {
        public static void AddMessaging(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new MessageBrokerSettings(configuration);

            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ctx, cfg) =>
                {

                    cfg.Host($"{settings.Protocol}://{settings.Host}:{settings.Port}", h =>
                    {
                        h.Username(settings.Username);
                        h.Password(settings.Password);
                    });

                    cfg.ConfigureEndpoints(ctx);
                });
            });

            services.AddScoped<IEventPublisher, EventPublisher>();
            services.AddSingleton(settings!);
        }
    }
}
