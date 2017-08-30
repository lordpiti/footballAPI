using DataAccess.Concrete;
using DataAccess.Interface;
using DataAccess.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using Microsoft.Extensions.Configuration;
using Football.DataAccess.Interface;
using Football.DataAccess.Concrete;

namespace Services
{
    public static class ServiceLayerBindings
    {
        public static IServiceCollection AddServiceLayerBindings(IServiceCollection services, IConfigurationRoot configuration)
        {
            return DataAccessLayerBindings
                .AddDataAccessLayerBindings(services, configuration)
                .AddScoped<IPlayerRepository, PlayerRepository>()
                .AddScoped<ITeamRepository, TeamRepository>();
        }
    }

}
