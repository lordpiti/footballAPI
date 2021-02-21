using Crosscutting.ViewModels;
using Football.DataAccessEFCore3.Interface;
using Football.DataAccessEFCore3.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;
using Football.Crosscutting.ViewModels;
using Football.Crosscutting;
using System.Threading.Tasks;
using Football.Crosscutting.ViewModels.Teams;

namespace Football.DataAccessEFCore3.Concrete
{
    public class TeamRepository : EFRepositoryBase<Equipo>, ITeamRepository
    {
        public TeamRepository(FootballContext context) : base(context)
        {
        }

        public async Task<Equipo> GetTeamByIdAndYear(int id)
        {
            try
            {
                var teamFromBD = await _context.Equipo.Include(x => x.TeamPictureGlobalMedia)
                    .Include(x => x.CodEstadioNavigation)
                    .Include(x => x.Jugador)
                    .ThenInclude(x => x.CodIntegranteNavigation.HcoIntegrante)
                    .Include(x => x.Jugador)
                    .ThenInclude(x => x.CodIntegranteNavigation.PictureGlobalMedia)
                    .FirstOrDefaultAsync(x => x.CodEquipo == id);

                return teamFromBD;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Equipo>> GetAllTeams(int? competitionId = null)
        {
            if (competitionId != null)
            {
                return await _context.EquiposParticipan.Where(x => x.CodCompeticion == competitionId)
                    .Include(x => x.CodEquipoNavigation).ThenInclude(x => x.TeamPictureGlobalMedia)
                    .Select(x => x.CodEquipoNavigation).ToListAsync();
            }
            else
            {
                return await _context.Equipo.Include(x => x.TeamPictureGlobalMedia).ToListAsync();
            }
        }

        public void AddTeamPicture(Equipo team, GlobalMedia globalMedia)
        {
            team.TeamPictureGlobalMedia = globalMedia;
        }

        public async Task<IEnumerable<Clasificacion>> GetTeamSeasonClasificationChartData(int teamId, 
            string competitionName, string season)
        {
            var clasificationSeasonData = await _context.Clasificacion
                .Include(x => x.CodCompeticionNavigation)
                .Where(x => x.CodEquipo == teamId 
                && x.CodCompeticionNavigation.Temporada == season 
                && x.CodCompeticionNavigation.Nombre == competitionName)
                .OrderBy(x=>x.Jornada).ToListAsync();

            return clasificationSeasonData;
        }

        public async Task<ClasificationChartData> GetTeamSeasonClasificationChartData(int teamId,
            int competitionId)
        {
            var clasificationSeasonData = await _context.Clasificacion.Include(x => x.CodCompeticionNavigation)
                .Where(x => x.CodEquipo == teamId && x.CodCompeticion == competitionId)
                .Select(x => new ClasificationRoundData()
                {
                    Position = x.Posicion,
                    GoalsAgainst = x.GolesContra,
                    GoalsFor = x.GolesFavor,
                    Round = x.Jornada
                })
                .OrderBy(x => x.Round).ToListAsync();

            var team = await _context.Equipo.FirstOrDefaultAsync(x => x.CodEquipo == teamId);

            return new ClasificationChartData()
            {
                Season = "",
                TeamName = team.Nombre,
                ClasificationSeasonData = clasificationSeasonData
            };
        }
    }
}
