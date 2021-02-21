using Football.Crosscutting;
using Football.Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services.Interface
{
    public interface ITeamService
    {
        Task<Team> GetTeamByIdAndYear(int id, int year);

        Task<IEnumerable<Team>> GetAllTeams(int? competitionId = null);

        Task<int> UpdateTeam(Team team);

        Task<ClasificationChartData> GetTeamSeasonClasificationChartData(int teamId,
            string competitionName, string season);

        Task<ClasificationChartData> GetTeamSeasonClasificationChartData(int teamId, int competitionId);

    }
}
