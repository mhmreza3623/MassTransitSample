using MassTransit.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.Infrastructure.Repositories
{
    public static class Startup
    {
        public static IServiceCollection AddRepositoriesConfig(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGeneralRepository<>), typeof(GeneralRepositories<>));

            return services;
        }
    }
}
