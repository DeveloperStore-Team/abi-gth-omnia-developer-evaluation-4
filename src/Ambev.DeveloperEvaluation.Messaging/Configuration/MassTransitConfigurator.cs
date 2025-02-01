using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MassTransit;
using Ambev.DeveloperEvaluation.Configuration;

namespace SalesEventConsumer.Configuration
{
    public static class MassTransitConfigurator
    {
        public static void AddMessaging(this IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                services.AddMassTransit(config =>
                {
                    config.UsingRabbitMq((ctx, cfg) =>
                    {
                        var rabbitMqHost = configuration["RabbitMQ:Host"] ?? "localhost";
                        var rabbitMqPort = configuration["RabbitMQ:Port"] ?? "5672";
                        var rabbitMqUsername = configuration["RabbitMQ:Username"] ?? "guest";
                        var rabbitMqPassword = configuration["RabbitMQ:Password"] ?? "guest";

                        cfg.Host($"amqp://{rabbitMqHost}:{rabbitMqPort}", h =>
                        {
                            h.Username(rabbitMqUsername);
                            h.Password(rabbitMqPassword);
                        });

                        cfg.ConfigureEndpoints(ctx);
                    });

                });

                services.AddScoped<IEventPublisher, EventPublisher>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Erro] Falha ao conectar com RabbitMQ: {ex.Message}");
                services.AddScoped<IEventPublisher, MockEventPublisher>();
            }
        }
    }
}
