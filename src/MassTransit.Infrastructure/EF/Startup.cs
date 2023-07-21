using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.Infrastructure.DataBase;
public static class Startup
{
    public static IServiceCollection AddDataBaseConfig(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddDbContext<MassTransitDbContext>(options =>
        {
            options.UseSqlServer(configurationManager.GetConnectionString("DefaultConnection"));
        });

        return services;
    }
}
