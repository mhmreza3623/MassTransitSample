using MassTransit.Core.Events.BaseEvents;
using MassTransit.Core.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransit.Infrastructure.EventHandlers;

public static class Startup
{
    public static IServiceCollection AddMassTransitConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var setting = new MassTransitConfiguration();
        configuration.GetSection(MassTransitConfiguration.SectionName).Bind(setting);

        services.AddMassTransit(config =>
        {
            config.AddConsumer<EventConsumer>();

            config.SetKebabCaseEndpointNameFormatter();
            config.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(setting.RabbitMqHostName ?? throw new NullReferenceException("The host has not been specififed for RabbitMQ"), x =>
                {
                    x.Username(setting.RabbitMqUsername ?? throw new NullReferenceException("The username has not been specififed for RabbitMQ"));
                    x.Password(setting.RabbitMqPassword ?? throw new NullReferenceException("The password has not been specififed for RabbitMQ"));
                });

                // Set up receiver endpoint for the ProductCreated event
                // using the contancts from the messagebus library
                // rabbitSettings.QueueName => service-b
                cfg.ReceiveEndpoint(EventBusConstants.GeneralQueue, e =>
                {
                    e.ConfigureConsumers(ctx);
                });

                // Add all consumers here...

            });
        });

        return services;
    }
}