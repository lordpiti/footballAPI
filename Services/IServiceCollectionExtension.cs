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
using Football.DataAccessNoSQL.Concrete;
using Football.DataAccessNoSQL.Interface;

namespace Services
{
    public static class ServiceLayerBindings
    {
        public static IServiceCollection AddServiceLayerBindings(IServiceCollection services, IConfigurationRoot configuration, bool transient = false)
        {
            var servicesOutput = DataAccessLayerBindings
                .AddDataAccessLayerBindings(services, configuration, transient)
                .AddScoped<ICompetitionRepository, CompetitionRepository>()
                .AddScoped<IUserRepository, UserRepository>();

            if (transient)
            {
                servicesOutput.AddTransient<IPlayerRepository, PlayerRepository>()
                                .AddTransient<ITeamRepository, TeamRepository>();
            }
            else
            {
                servicesOutput.AddScoped<IPlayerRepository, PlayerRepository>()
                                .AddScoped<ITeamRepository, TeamRepository>();
            }

            return servicesOutput;
        }
    }

}
