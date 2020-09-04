using Football.DataAccessEFCore3.Models;
using Microsoft.Extensions.DependencyInjection;
using DataAccess;
using Microsoft.Extensions.Configuration;
using Football.DataAccessEFCore3.Interface;
using Football.DataAccessEFCore3.Concrete;
using Football.DataAccessNoSQL.Concrete;
using Football.DataAccessNoSQL.Interface;
using Football.Services.Proxy;
using Football.Services.Proxy.Configuration;

namespace Services
{
    public static class ServiceLayerBindings
    {
        public static IServiceCollection AddServiceLayerBindings(IServiceCollection services, IConfigurationRoot configuration, bool transient = false)
        {
            var servicesOutput = DataAccessLayerBindings
                .AddDataAccessLayerBindings(services, configuration, transient)
                .AddScoped<ICompetitionRepository, CompetitionRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IReportNoSQLRepository, ReportNoSQLRepository>()
                .AddScoped<IReportRepository, ReportRepository>()
                .AddScoped<IGlobalMediaRepository, GlobalMediaRepository>()
                .AddSingleton<TopSquadApiConfiguration>()
                .AddScoped<ITopSquadApiClient, TopSquadApiClient>();

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
