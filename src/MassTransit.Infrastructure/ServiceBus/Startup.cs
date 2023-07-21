using AutoMapper.Configuration;
using MassTransit.Infrastructure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransit.Infrastructure.ServiceBus;

public static class Startup
{
    public static void AddMassTransitConfig(this IServiceCollection services, ConfigurationManager configuration)
    {

        var config = new MassTransitConfiguration();
        configuration.GetSection(MassTransitConfiguration.SectionName).Bind(config);

        services.AddMassTransit(options =>
        {

            options.UsingRabbitMq((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
                cfg.Host(config.RabbitMqHostName, config.RabbitMqVirtualHost, h =>
                {
                    h.Username(config.RabbitMqUsername);
                    h.Password(config.RabbitMqPassword);
                });
            });


        });

        services.Configure<MassTransitConfiguration>(configuration.GetSection(MassTransitConfiguration.SectionName));

    }
}