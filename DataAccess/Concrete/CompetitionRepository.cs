using DataAccess.Concrete;
using DataAccess.Models;
using Football.Crosscutting.ViewModels.Competition;
using Football.DataAccess.Interface;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Teams;
using Football.Crosscutting;

namespace Football.DataAccess.Concrete
{
    public class CompetitionRepository : EFRepositoryBase, ICompetitionRepository
    {
        public CompetitionRepository(c__database_futbol_mdfContext context) : base(context)
        {
        }
        
        public async Task<List<Competition>> GetCompetitions(int? teamId =null, string season=null)
        {
            if (teamId == null)
            {
                var ey = _context.Competicion.ToAsyncEnumerable();

                if (!string.IsNullOrEmpty(season))
                {
                    ey = ey.Where(x => x.Temporada == season);
                }

                return await ey.Select(x=>new Competition()
                {
                    Id = x.CodCompeticion,
                    Name = x.Nombre,
                    Season = x.Temporada,
                    Type = x.Tipo
                }).ToList();
            }

            return await _context.EquiposParticipan.Include(x => x.Competicion)
            .Where(x => x.CodEquipo == teamId)
            .Select(x => new Competition{
                Name = x.Competicion.Nombre,
                Season = x.Competicion.Temporada,
                Id = x.CodCompeticion,
                Type = x.Competicion.Tipo
            }).ToListAsync();
            
        }

        public async Task<List<MatchGeneralInfo>> GetMatches(int competitionId, string round)
        {
            return await _context.Calendario
                .Where(x => x.CodCompeticion == competitionId && x.Jornada == round)
                .Include(x=>x.Match).Select(x=>x.Match)
                .Include(x=>x.CodLocalNavigation.TeamPicture)
                .Include(x=>x.CodLocalNavigation.Stadium)
                .Include(x=>x.CodVisitanteNavigation.TeamPicture)
                .Include(x=>x.CodVisitanteNavigation.Stadium)
                .Select(x=> new MatchGeneralInfo() {
                    Date = x.Fecha,
                    GoalsLocal = x.GolesLocal,
                    GoalsVisitor = x.GolesVisitante,
                    MatchId = x.CodPartido,
                    LocalTeam = new Team()
                    {
                        Name = x.CodLocalNavigation.Nombre,
                        Id = x.CodLocalNavigation.CodEquipo,
                        PictureLogo = new Crosscutting.BlobData()
                        {
                            ContainerReference = x.CodLocalNavigation.TeamPicture.BlobStorageContainer,
                            FileName = x.CodLocalNavigation.TeamPicture.BlobStorageReference
                        }
                    },
                    VisitorTeam = new Team()
                    {
                        Name = x.CodVisitanteNavigation.Nombre,
                        Id = x.CodVisitanteNavigation.CodEquipo,
                        PictureLogo = new Crosscutting.BlobData()
                        {
                            ContainerReference = x.CodVisitanteNavigation.TeamPicture.BlobStorageContainer,
                            FileName = x.CodVisitanteNavigation.TeamPicture.BlobStorageReference
                        }
                    },
                    Stadium = new Stadium()
                    {
                        Id = x.CodEstadioNavigation.CodEstadio,
                        Name = x.CodEstadioNavigation.Nombre
                    }
                }).ToListAsync();
        }

        public async Task<CompetitionRoundData> GetCompetitionRoundData(int competitionId, string round)
        {
            var matchList = await _context.Calendario
                .Where(x => x.CodCompeticion == competitionId && x.Jornada == round)
                .Include(x => x.Match).Select(x => x.Match)
                .Include(x => x.CodLocalNavigation.TeamPicture)
                .Include(x => x.CodLocalNavigation.Stadium)
                .Include(x => x.CodVisitanteNavigation.TeamPicture)
                .Include(x => x.CodVisitanteNavigation.Stadium)
                .Select(x => new MatchGeneralInfo()
                {
                    Date = x.Fecha,
                    GoalsLocal = x.GolesLocal,
                    GoalsVisitor = x.GolesVisitante,
                    MatchId = x.CodPartido,
                    LocalTeam = new Team()
                    {
                        Name = x.CodLocalNavigation.Nombre,
                        Id = x.CodLocalNavigation.CodEquipo,
                        PictureLogo = new Crosscutting.BlobData()
                        {
                            ContainerReference = x.CodLocalNavigation.TeamPicture.BlobStorageContainer,
                            FileName = x.CodLocalNavigation.TeamPicture.BlobStorageReference
                        }
                    },
                    VisitorTeam = new Team()
                    {
                        Name = x.CodVisitanteNavigation.Nombre,
                        Id = x.CodVisitanteNavigation.CodEquipo,
                        PictureLogo = new Crosscutting.BlobData()
                        {
                            ContainerReference = x.CodVisitanteNavigation.TeamPicture.BlobStorageContainer,
                            FileName = x.CodVisitanteNavigation.TeamPicture.BlobStorageReference
                        }
                    },
                    Stadium = new Stadium()
                    {
                        Id = x.CodEstadioNavigation.CodEstadio,
                        Name = x.CodEstadioNavigation.Nombre
                    }
                }).ToListAsync();



            var clasificationData = await _context.Clasificacion.Include(x => x.CodEquipoNavigation)
                .Where(x => x.CodCompeticion == competitionId && x.Jornada == Convert.ToInt32(round))
                .OrderBy(x => x.Posicion).Select(x => new TeamStatsRound()
                {
                    Position = x.Posicion,
                    TeamId = x.CodEquipo,
                    TeamLogo = x.CodEquipoNavigation.TeamPicture != null ? new BlobData()
                    {
                        ContainerReference = x.CodEquipoNavigation.TeamPicture.BlobStorageContainer,
                        FileName = x.CodEquipoNavigation.TeamPicture.BlobStorageReference
                    } : new BlobData(),
                    TeamName = x.CodEquipoNavigation.Nombre,
                    GoalsAgainst = x.GolesContra,
                    GoalsFor = x.GolesFavor,
                    MatchesDraw = x.Empatados,
                    MatchesLost = x.Perdidos,
                    MatchesWon = x.Ganados,
                    Points = x.Puntos
                }).ToListAsync();

            return new CompetitionRoundData()
            {
                MatchList = matchList,
                TeamStatsRoundList = clasificationData
            };
        }
    }
}
