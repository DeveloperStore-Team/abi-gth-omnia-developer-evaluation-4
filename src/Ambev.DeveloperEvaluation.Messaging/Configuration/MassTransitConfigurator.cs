using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MassTransit;

namespace SalesEventConsumer.Configuration
{
    public static class MassTransitConfigurator
    {
        public static void AddMessaging(this IServiceCollection services, IConfiguration configuration)
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
        }
    }
}
