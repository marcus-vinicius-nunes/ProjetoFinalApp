using Microsoft.Extensions.Options;
using ProdutosApp.Domain.Interfaces.Messages;
using ProdutosApp.Infra.Messages.Producers;
using ProdutosApp.Infra.Messages.Settings;
using RabbitMQ.Client;

namespace ProdutosApp.API.Extensions
{
    public static class MessagesConfigExtension
    {
        public static IServiceCollection AddMessagesConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMQSettings = new RabbitMQSettings();
            new ConfigureFromConfigurationOptions<RabbitMQSettings>
                (configuration.GetSection("RabbitMQ")).Configure(rabbitMQSettings);

            services.AddSingleton(rabbitMQSettings);

            services.AddSingleton<IConnectionFactory>(cf => 
            {
                var config = cf.GetRequiredService<RabbitMQSettings>();
                return new ConnectionFactory
                {
                    HostName = config.Hostname,
                    Port = config.Port.Value,
                    UserName = config.Username,
                    Password = config.Password,
                    VirtualHost = config.Username
                };
            });

            services.AddTransient<IMessageProducer, MessageProducer>();

            return services;
        }
    }
}
