using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MassTransit;

namespace SalesEventMessaging.Configuration
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

                    cfg.Host($"rabbitmq://{rabbitMqHost}:{rabbitMqPort}", h =>
                    {
                        h.Username(rabbitMqUsername);
                        h.Password(rabbitMqPassword);
                        h.UseSsl(s =>
                        {
                            s.Protocol = System.Security.Authentication.SslProtocols.Tls12;
                        });
                    });

                    cfg.UseMessageRetry(r => r.Interval(5, TimeSpan.FromSeconds(10)));
                                       
                    cfg.PrefetchCount = 10;
                    cfg.ConcurrentMessageLimit = 5;

                    cfg.ReceiveEndpoint("error_queue", e =>
                    {
                        e.ConfigureConsumeTopology = false;
                        e.BindDeadLetterQueue("original_queue", "error_queue");
                    });
                });
            });
        }
    }
}
