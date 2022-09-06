using Application.Services.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Contexts;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class PersistanceServiceRegistiration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<SQLContext>();
            services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
            return services;
        }
    }
}
