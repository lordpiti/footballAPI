using DataAccess.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public static class DataAccessLayerBindings
    {
        public static IServiceCollection AddDataAccessLayerBindings(IServiceCollection services, IConfigurationRoot configuration)
        {
            var connectionString = configuration.GetSection("AppSettings:ConnectionString").Value;

            services
                .AddDbContext<c__database_futbol_mdfContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }
    }
}
