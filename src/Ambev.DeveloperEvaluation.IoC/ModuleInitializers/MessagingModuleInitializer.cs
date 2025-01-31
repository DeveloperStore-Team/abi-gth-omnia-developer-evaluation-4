using Ambev.DeveloperEvaluation.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SalesEventConsumer.Configuration;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers
{
    public class MessagingModuleInitializer : IModuleInitializer
    {
        public void Initialize(WebApplicationBuilder builder)
        {
            builder.Services.AddMessaging(builder.Configuration);
            builder.Services.AddScoped<IEventPublisher, EventPublisher>();
        }
    }
}
