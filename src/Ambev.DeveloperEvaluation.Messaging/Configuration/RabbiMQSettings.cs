using Microsoft.Extensions.Configuration;

namespace Ambev.DeveloperEvaluation.Messaging.Configuration
{
    public class MessageBrokerSettings
    {
        public string? Protocol { get; set; }
        public string? Host { get; set; }
        public int? Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double? PublishTimeoutSeconds { get; set; }

        public MessageBrokerSettings(IConfiguration configuration)
        {
            var section = configuration.GetSection("MessageBroker");

            Protocol = section.GetValue("Protocol", "amqp");
            Host = section.GetValue("Host", "localhost");
            Port = section.GetValue("Port", 5672);
            Username = section.GetValue("Username", "guest");
            Password = section.GetValue("Password", "guest");
            PublishTimeoutSeconds = section.GetValue("PublishTimeoutSeconds", 5);
        }
    }
}
