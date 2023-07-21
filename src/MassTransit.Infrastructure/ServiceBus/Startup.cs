using MassTransit;
using MassTransit.Core.Shared.ServiceBus;
using MassTransit.Infrastructure.Services.Consume;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransit.Infrastructure.ServiceBus;

public static class Startup
{
    public static IServiceCollection AddMassTransitConfig(this IServiceCollection services, IConfiguration configuration)
    {

        var config = new MassTransitConfiguration();

        configuration.GetSection(MassTransitConfiguration.SectionName).Bind(config);

        services.AddMassTransit(options =>
        {
            options.AddConsumer<EventConsumer>();

            options.UsingRabbitMq((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
                cfg.Host(config.RabbitMqHostName, config.RabbitMqVirtualHost, h =>
                {
                    h.Username(config.RabbitMqUsername);
                    h.Password(config.RabbitMqPassword);
                });

                cfg.ReceiveEndpoint(EventBusConstants.GeneralQueue, cfgEndpoint =>
                {
                    cfgEndpoint.ConfigureConsumer<EventConsumer>(context);
                });
            });


        });

        services.Configure<MassTransitConfiguration>(configuration.GetSection(MassTransitConfiguration.SectionName));

        return services;
    }
}