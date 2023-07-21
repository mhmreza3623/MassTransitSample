using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransit.Infrastructure.MongoDb;
public static class Startup
{
    public static IServiceCollection AddDataBaseConfig(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
