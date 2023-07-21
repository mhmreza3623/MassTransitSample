using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransit.Infrastructure.EF;
public static class Startup
{
    public static void AddEfConfig(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddDbContext<MassTransitDbContext>(options =>
        {
            options.UseSqlServer(configurationManager.GetConnectionString("DefaultConnection"));
        });

    }
}
