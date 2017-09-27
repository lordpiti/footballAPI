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
using Football.Crosscutting.ViewModels.Match;

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

        public async Task<MatchOverview> GetMatchOverview(int matchId)
        {
            var match = await _context.Partido
                .Include(x => x.CodLocalNavigation.TeamPicture)
                .Include(x => x.CodLocalNavigation.Stadium)
                .Include(x => x.CodVisitanteNavigation.TeamPicture)
                .Include(x => x.CodVisitanteNavigation.Stadium)
                .FirstOrDefaultAsync(x=>x.CodPartido == matchId);

            var players = await _context.PartidoJugado
                .Include(x => x.CodPartidoNavigation)
                .Include(x=>x.CodJugadorNavigation).ThenInclude(x=>x.CodIntegranteNavigation).ThenInclude(x=>x.HcoIntegrante)
                .Where(x => x.CodPartido == matchId)
                    .Select(x=>new Player()
                    {
                        Name = x.CodJugadorNavigation.CodIntegranteNavigation.Nombre,
                        Surname = x.CodJugadorNavigation.CodIntegranteNavigation.Apellidos,
                        TeamId = x.CodJugadorNavigation.CodIntegranteNavigation.HcoIntegrante
                            .FirstOrDefault().CodEquipo,
                        Dorsal = x.CodJugadorNavigation.CodIntegranteNavigation.HcoIntegrante
                            .FirstOrDefault().Dorsal
                        //These are the right queries, but the database is not properly populated yet ... so i stick to the version above for the moment
                        //TeamId = x.CodJugadorNavigation.CodIntegranteNavigation.HcoIntegrante
                        //    .FirstOrDefault(y => y.FechaInicio < x.CodPartidoNavigation.Fecha && (y.FechaFin > x.CodPartidoNavigation.Fecha || y.FechaFin == null)).CodEquipo,
                        //Dorsal = x.CodJugadorNavigation.CodIntegranteNavigation.HcoIntegrante
                        //    .FirstOrDefault(y=>y.FechaInicio<x.CodPartidoNavigation.Fecha && (y.FechaFin>x.CodPartidoNavigation.Fecha || y.FechaFin == null)).Dorsal
                    })
                    .ToListAsync();

            var matchOverview = new MatchOverview()
            {
                Players = players,
                MatchGeneralInfo = new MatchGeneralInfo()
                {
                    Date = match.Fecha,
                    GoalsLocal = match.GolesLocal,
                    GoalsVisitor = match.GolesVisitante,
                    MatchId = match.CodPartido,
                    LocalTeam = new Team()
                    {
                        Name = match.CodLocalNavigation.Nombre,
                        Id = match.CodLocalNavigation.CodEquipo,
                        PictureLogo = match.CodLocalNavigation.TeamPicture!=null? new Crosscutting.BlobData()
                        {
                            ContainerReference = match.CodLocalNavigation.TeamPicture.BlobStorageContainer,
                            FileName = match.CodLocalNavigation.TeamPicture.BlobStorageReference
                        }: new Crosscutting.BlobData()
                    },
                    VisitorTeam = new Team()
                    {
                        Name = match.CodVisitanteNavigation.Nombre,
                        Id = match.CodVisitanteNavigation.CodEquipo,
                        PictureLogo = match.CodVisitanteNavigation.TeamPicture!=null?new Crosscutting.BlobData()
                        {
                            ContainerReference = match.CodVisitanteNavigation.TeamPicture.BlobStorageContainer,
                            FileName = match.CodVisitanteNavigation.TeamPicture.BlobStorageReference
                        } : new Crosscutting.BlobData()
                    },
                    Stadium = new Stadium()
                    {
                        Id = match.CodEstadioNavigation.CodEstadio,
                        Name = match.CodEstadioNavigation.Nombre
                    }
                }
            };

            return matchOverview;
        }
    }
}
