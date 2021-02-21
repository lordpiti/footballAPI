using Football.Crosscutting;
using Football.Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Teams;
using Football.DataAccessEFCore3.Concrete;
using Football.DataAccessEFCore3.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.DataAccessEFCore3.Interface
{
    public interface ITeamRepository : IRepositoryBase<Equipo>
    {
        Task<Equipo> GetTeamByIdAndYear(int id);

        Task<IEnumerable<Equipo>> GetAllTeams(int? competitionId = null);

        void AddTeamPicture(Equipo team, GlobalMedia globalMedia);

        Task<IEnumerable<Clasificacion>> GetTeamSeasonClasificationChartData(int teamId,
                    string competitionName, string season);

        Task<ClasificationChartData> GetTeamSeasonClasificationChartData(int teamId,
            int competitionId);

    }
}
