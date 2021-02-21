using Football.DataAccessEFCore3.Models;
using Football.Crosscutting.ViewModels.Competition;
using Football.DataAccessEFCore3.Interface;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Teams;
using Football.Crosscutting;
using Football.Crosscutting.ViewModels.Match;

namespace Football.DataAccessEFCore3.Concrete
{
    public class CompetitionRepository : EFRepositoryBase<Competicion>, ICompetitionRepository
    {
        public CompetitionRepository(FootballContext context) : base(context)
        {
        }
        
        public async Task<List<Competition>> GetCompetitions(int? teamId =null, string season=null)
        {
            if (teamId == null)
            {
                var ey = await _context.Competicion.ToListAsync();

                if (!string.IsNullOrEmpty(season))
                {
                    ey = ey.Where(x => x.Temporada == season).ToList();
                }

                return ey.Select(x=>new Competition()
                {
                    Id = x.CodCompeticion,
                    Name = x.Nombre,
                    Season = x.Temporada,
                    Type = x.Tipo
                }).ToList();
            }

            return await _context.EquiposParticipan.Include(x => x.CodCompeticionNavigation)
            .Where(x => x.CodEquipo == teamId)
            .Select(x => new Competition{
                Name = x.CodCompeticionNavigation.Nombre,
                Season = x.CodCompeticionNavigation.Temporada,
                Id = x.CodCompeticion,
                Type = x.CodCompeticionNavigation.Tipo
            }).ToListAsync();
            
        }

        public async Task<List<MatchGeneralInfo>> GetMatches(int competitionId, string round)
        {
            return await _context.Calendario
                .Where(x => x.CodCompeticion == competitionId && x.Jornada == round)
                .Include(x=> x.MatchCodPartidoNavigation).Select(x=>x.MatchCodPartidoNavigation)
                .Include(x=>x.CodLocalNavigation.TeamPictureGlobalMedia)
                .Include(x=>x.CodLocalNavigation.CodEstadioNavigation)
                .Include(x=>x.CodVisitanteNavigation.TeamPictureGlobalMedia)
                .Include(x=>x.CodVisitanteNavigation.CodEstadioNavigation)
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
                            ContainerReference = x.CodLocalNavigation.TeamPictureGlobalMedia.BlobStorageContainer,
                            FileName = x.CodLocalNavigation.TeamPictureGlobalMedia.BlobStorageReference
                        }
                    },
                    VisitorTeam = new Team()
                    {
                        Name = x.CodVisitanteNavigation.Nombre,
                        Id = x.CodVisitanteNavigation.CodEquipo,
                        PictureLogo = new Crosscutting.BlobData()
                        {
                            ContainerReference = x.CodVisitanteNavigation.TeamPictureGlobalMedia.BlobStorageContainer,
                            FileName = x.CodVisitanteNavigation.TeamPictureGlobalMedia.BlobStorageReference
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
            try
            {
                var matchListQuery = await _context.Calendario
                    .Where(x => x.CodCompeticion == competitionId && x.Jornada == round)
                    .Include(x => x.MatchCodPartidoNavigation)
                    .ThenInclude(x => x.CodLocalNavigation.TeamPictureGlobalMedia)
                    .Include(x => x.MatchCodPartidoNavigation)
                    .ThenInclude(x => x.CodLocalNavigation.CodEstadioNavigation)
                    .Include(x => x.MatchCodPartidoNavigation)
                    .ThenInclude(x => x.CodVisitanteNavigation.TeamPictureGlobalMedia)
                    .Include(x => x.MatchCodPartidoNavigation)
                    .ThenInclude(x => x.CodVisitanteNavigation.CodEstadioNavigation)
                    .ToListAsync();
                    
                var matchList = matchListQuery
                    .Select(x => new MatchGeneralInfo()
                    {
                        Date = x.Fecha,
                        GoalsLocal = x.MatchCodPartidoNavigation.GolesLocal,
                        GoalsVisitor = x.MatchCodPartidoNavigation.GolesVisitante,
                        MatchId = x.MatchCodPartidoNavigation.CodPartido,
                        LocalTeam = new Team()
                        {
                            Name = x.MatchCodPartidoNavigation.CodLocalNavigation.Nombre,
                            Id = x.MatchCodPartidoNavigation.CodLocalNavigation.CodEquipo,
                            PictureLogo = new Crosscutting.BlobData()
                            {
                                ContainerReference = x.MatchCodPartidoNavigation.CodLocalNavigation.TeamPictureGlobalMedia.BlobStorageContainer,
                                FileName = x.MatchCodPartidoNavigation.CodLocalNavigation.TeamPictureGlobalMedia.BlobStorageReference
                            }
                        },
                        VisitorTeam = new Team()
                        {
                            Name = x.MatchCodPartidoNavigation.CodVisitanteNavigation.Nombre,
                            Id = x.MatchCodPartidoNavigation.CodVisitanteNavigation.CodEquipo,
                            PictureLogo = new Crosscutting.BlobData()
                            {
                                ContainerReference = x.MatchCodPartidoNavigation.CodVisitanteNavigation.TeamPictureGlobalMedia.BlobStorageContainer,
                                FileName = x.MatchCodPartidoNavigation.CodVisitanteNavigation.TeamPictureGlobalMedia.BlobStorageReference
                            }
                        },
                        Stadium = new Stadium()
                        {
                            Id = x.MatchCodPartidoNavigation.CodEstadioNavigation.CodEstadio,
                            Name = x.MatchCodPartidoNavigation.CodEstadioNavigation.Nombre
                        }
                    }).ToList();


                var clasificationData = await _context.Clasificacion.Include(x => x.CodEquipoNavigation)
                    .Where(x => x.CodCompeticion == competitionId && x.Jornada == Convert.ToInt32(round))
                    .OrderBy(x => x.Posicion).Select(x => new TeamStatsRound()
                    {
                        Position = x.Posicion,
                        TeamId = x.CodEquipo,
                        TeamLogo = x.CodEquipoNavigation.TeamPictureGlobalMedia != null ? new BlobData()
                        {
                            ContainerReference = x.CodEquipoNavigation.TeamPictureGlobalMedia.BlobStorageContainer,
                            FileName = x.CodEquipoNavigation.TeamPictureGlobalMedia.BlobStorageReference
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
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public async Task<MatchOverview> GetMatchOverview(int matchId)
        {
            #region Get Match Data

            var match = await _context.Partido
                .Include(x=>x.CodEstadioNavigation)
                .Include(x => x.CodLocalNavigation.TeamPictureGlobalMedia)
                .Include(x => x.CodLocalNavigation.CodEstadioNavigation)
                .Include(x => x.CodVisitanteNavigation.TeamPictureGlobalMedia)
                .Include(x => x.CodVisitanteNavigation.CodEstadioNavigation)
                .FirstOrDefaultAsync(x=>x.CodPartido == matchId);

            #endregion

            #region Get Player data and game statistics

            // This code is to run a query to get all required data at once
            // Before, it was split into different smaller queries, which can be seen
            // commented below

            var players = await _context.PartidoJugado
                .Where(x => x.CodPartido == matchId)
                .Include(x => x.CodPartidoNavigation)
                .Include(x=>x.CodJugadorNavigation).ThenInclude(x=>x.CodIntegranteNavigation).ThenInclude(x=>x.HcoIntegrante)
                .Include(x =>x.CodJugadorNavigation).ThenInclude(x=>x.Tarjeta)
                .Include(x => x.CodJugadorNavigation).ThenInclude(x => x.Gol)        
                    .Select(x=>new MatchPlayerDataTotal()
                    {
                        PlayerId = x.CodJugador,
                        Name = x.CodJugadorNavigation.CodIntegranteNavigation.Nombre,
                        Surname = x.CodJugadorNavigation.CodIntegranteNavigation.Apellidos,
                        TeamId = x.CodJugadorNavigation.CodIntegranteNavigation.HcoIntegrante
                            .FirstOrDefault().CodEquipo,
                        Dorsal = x.CodJugadorNavigation.CodIntegranteNavigation.HcoIntegrante
                            .FirstOrDefault().Dorsal,
                        Start = x.Titular == "Titular",
                        Bookings = x.CodJugadorNavigation.Tarjeta.Where(x => x.CodPartido == matchId).Select(t => new Booking()
                        {
                            Minute = t.Minuto,
                            Type = t.Tipo,
                            Player = new Player()
                            {
                                PlayerId = x.CodJugador,
                                Name = x.CodJugadorNavigation.CodIntegranteNavigation.Nombre,
                                Surname = x.CodJugadorNavigation.CodIntegranteNavigation.Apellidos
                            }
                        }),
                        Goals = x.CodJugadorNavigation.Gol.Where(x => x.CodPartido == matchId).Select(g => new Goal()
                        {
                            Minute = g.Minuto,
                            Type = g.Tipo,
                            VideoUrl = g.Video,
                            Player = new Player()
                            {
                                PlayerId = x.CodJugador,
                                Name = x.CodJugadorNavigation.CodIntegranteNavigation.Nombre,
                                Surname = x.CodJugadorNavigation.CodIntegranteNavigation.Apellidos
                            }
                        })
                        //These are the right queries, but the database is not properly populated yet ... so i stick to the version above for the moment
                        //TeamId = x.CodJugadorNavigation.CodIntegranteNavigation.HcoIntegrante
                        //    .FirstOrDefault(y => y.FechaInicio < x.CodPartidoNavigation.Fecha && (y.FechaFin > x.CodPartidoNavigation.Fecha || y.FechaFin == null)).CodEquipo,
                        //Dorsal = x.CodJugadorNavigation.CodIntegranteNavigation.HcoIntegrante
                        //    .FirstOrDefault(y=>y.FechaInicio<x.CodPartidoNavigation.Fecha && (y.FechaFin>x.CodPartidoNavigation.Fecha || y.FechaFin == null)).Dorsal
                    })
                    .ToListAsync();

            #endregion

            #region Old queries to get boookings and goals separately

            //var bookings = await _context.Tarjeta.Include(x => x.CodJugadorNavigation).ThenInclude(x=>x.CodIntegranteNavigation)
            //    .Where(x => x.CodPartido == matchId)
            //    .Select(x => new Booking()
            //    {
            //        Minute = x.Minuto,
            //        Type = x.Tipo,
            //        Player = new Player()
            //         {
            //            PlayerId = x.CodJugador,
            //            Name = x.CodJugadorNavigation.CodIntegranteNavigation.Nombre,
            //            Surname = x.CodJugadorNavigation.CodIntegranteNavigation.Apellidos
            //         }
            //    }).ToListAsync();

            //var goals = await _context.Gol.Include(x => x.CodJugadorNavigation).ThenInclude(x => x.CodIntegranteNavigation)
            //    .Where(x => x.CodPartido == matchId)
            //    .Select(x => new Goal()
            //    {
            //        Minute = x.Minuto,
            //        Type = x.Tipo,
            //        VideoUrl =x.Video,
            //        Player = new Player()
            //        {
            //            PlayerId = x.CodJugador,
            //            Name = x.CodJugadorNavigation.CodIntegranteNavigation.Nombre,
            //            Surname = x.CodJugadorNavigation.CodIntegranteNavigation.Apellidos
            //        }
            //    }).ToListAsync();
            #endregion

            #region Get Substitute data

            var substitutions = await _context.Cambio.Include(x => x.CodJugadorSaleNavigation).ThenInclude(x => x.CodIntegranteNavigation)
                .Include(x => x.CodJugadorEntraNavigation).ThenInclude(x => x.CodIntegranteNavigation)
                .Where(x => x.CodPartido == matchId)
                .Select(x => new Substitution()
                {
                    Minute = x.Minuto,
                    PlayerIn = new Player()
                    {
                        PlayerId = x.CodJugadorEntra,
                        Name = x.CodJugadorEntraNavigation.CodIntegranteNavigation.Nombre,
                        Surname = x.CodJugadorEntraNavigation.CodIntegranteNavigation.Apellidos
                    },
                    PlayerOut = new Player()
                    {
                        PlayerId = x.CodJugadorSale,
                        Name = x.CodJugadorSaleNavigation.CodIntegranteNavigation.Nombre,
                        Surname = x.CodJugadorSaleNavigation.CodIntegranteNavigation.Apellidos
                    }
                }).ToListAsync();

            #endregion

            var matchOverview = new MatchOverview()
            {
                Players = players.ToList<Player>(),
                StatisticsIncidences = new StatisticsIncidences()
                {
                    Bookings = players.SelectMany(x => x.Bookings).ToList(),
                    Goals = players.SelectMany(x => x.Goals).ToList(),
                    Substitutions = substitutions,
                    CornersLocal = match.CornersLocal,
                    CornersVisitor = match.CornersVisitante,
                    OffsideLocal = match.FuerasJuegoLocal,
                    OffsideVisitor = match.FuerasJuegoVisitante,
                    PosessionLocal = match.PosesionLocal,
                    PosessionVisitor = match.PosesionVisitante
                },
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
                        PictureLogo = match.CodLocalNavigation.TeamPictureGlobalMedia != null ? new Crosscutting.BlobData()
                        {
                            ContainerReference = match.CodLocalNavigation.TeamPictureGlobalMedia.BlobStorageContainer,
                            FileName = match.CodLocalNavigation.TeamPictureGlobalMedia.BlobStorageReference
                        } : new Crosscutting.BlobData()
                    },
                    VisitorTeam = new Team()
                    {
                        Name = match.CodVisitanteNavigation.Nombre,
                        Id = match.CodVisitanteNavigation.CodEquipo,
                        PictureLogo = match.CodVisitanteNavigation.TeamPictureGlobalMedia != null ? new Crosscutting.BlobData()
                        {
                            ContainerReference = match.CodVisitanteNavigation.TeamPictureGlobalMedia.BlobStorageContainer,
                            FileName = match.CodVisitanteNavigation.TeamPictureGlobalMedia.BlobStorageReference
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

        public async Task<Competition> GetCompetitionById(int competitionId)
        {
            var competition = await _context.Competicion.Include(x=>x.CompetitionLogoGlobalMedia).FirstOrDefaultAsync(x=>x.CodCompeticion == competitionId);

            var rounds = await _context.Calendario.Where(x => x.CodCompeticion == competitionId).Select(x => x.Jornada).Distinct().OrderBy(x=>x.Length).ThenBy(x=>x).ToListAsync();

            return new Competition()
            {
                Id = competition.CodCompeticion,
                Name = competition.Nombre,
                RoundList = rounds,
                Season = competition.Temporada,
                Type = competition.Tipo,
                Logo = competition.CompetitionLogoGlobalMedia!=null?new BlobData()
                {
                    ContainerReference = competition.CompetitionLogoGlobalMedia.BlobStorageContainer,
                    FileName = competition.CompetitionLogoGlobalMedia.BlobStorageReference
                }:new BlobData()
            };
        }

        public async Task<List<Scorer>> GetTopScorers(int competitionId, string round)
        {
            try
            {
                var scorersGrouped = await _context.Gol.Include(x => x.CodPartidoNavigation).ThenInclude(x => x.CodCompeticionNavigation)
                    .Include(x => x.CodJugadorNavigation).ThenInclude(x=>x.CodIntegranteNavigation)
                    .Include(x => x.CodJugadorNavigation).ThenInclude(x => x.CodEquipoNavigation)
                    .Where(x => x.CodPartidoNavigation.CodCompeticion == competitionId && Convert.ToInt32(x.CodPartidoNavigation.Jornada)<=Convert.ToInt32(round))
                    .ToListAsync();

                var result = scorersGrouped.GroupBy(x => x.CodJugadorNavigation).Select(x => new Scorer{
                    Player = new Player() {
                        Name = x.Key.CodIntegranteNavigation.Nombre,
                        Surname = x.Key.CodIntegranteNavigation.Apellidos,
                        PlayerId = x.Key.CodJugador,
                        TeamId = (int)x.Key.CodEquipo,
                        TeamName = x.Key.CodEquipoNavigation.Nombre
                    },
                    Goals = x.Count() })
                    .OrderByDescending(x=>x.Goals).ToList();
                    
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<TournamentDraw> GetDraw(int competitionId)
        {
            var sixteenQuery = await _context.Partido
                .Include(x => x.CodLocalNavigation.TeamPictureGlobalMedia)
                .Include(x => x.CodVisitanteNavigation.TeamPictureGlobalMedia)
                .Include(x => x.CodEstadioNavigation)
                .Where(match => match.CodCompeticion == competitionId && match.Jornada == "1/8 Final")
                .ToListAsync();

            var sixteen = sixteenQuery
                .Select(x => createMatchFromDb(x)).ToList();

            var eightQuery = await _context.Partido
                .Include(x => x.CodLocalNavigation.TeamPictureGlobalMedia)
                .Include(x => x.CodVisitanteNavigation.TeamPictureGlobalMedia)
                .Include(x => x.CodEstadioNavigation)
                .Where(match => match.CodCompeticion == competitionId && match.Jornada == "1/4 Final")
                .ToListAsync();

            var eight = eightQuery.Select(x => createMatchFromDb(x)).ToList();

            var semifinalsQuery = await _context.Partido
                .Include(x => x.CodLocalNavigation.TeamPictureGlobalMedia)
                .Include(x => x.CodVisitanteNavigation.TeamPictureGlobalMedia)
                .Include(x => x.CodEstadioNavigation)
                .Where(match => match.CodCompeticion == competitionId &&  match.Jornada == "Semifinal")
                .ToListAsync();

            var semifinals = semifinalsQuery.Select(x => createMatchFromDb(x)).ToList();

            var final = await _context.Partido
                .Include(x => x.CodLocalNavigation.TeamPictureGlobalMedia)
                .Include(x => x.CodVisitanteNavigation.TeamPictureGlobalMedia)
                .Include(x => x.CodEstadioNavigation)
                .FirstOrDefaultAsync(match => match.CodCompeticion == competitionId && match.Jornada == "Final");

            var finalMatch = createMatchFromDb(final);

            #region SF

            var semifinalLeft = getMatchPreviousRound(finalMatch.LocalTeam.Id, semifinals);
            var semifinalRight = getMatchPreviousRound(finalMatch.VisitorTeam.Id, semifinals);

            #endregion

            #region QF

            var qfListLeft = new List<MatchGeneralInfo>();

            var qfLeft1 = getMatchPreviousRound(semifinalLeft.LocalTeam.Id, eight);
            var qfLeft2 = getMatchPreviousRound(semifinalLeft.VisitorTeam.Id, eight);

            qfListLeft.Add(qfLeft1);
            qfListLeft.Add(qfLeft2);

            var qfListRight = new List<MatchGeneralInfo>();

            var qfRight1 = getMatchPreviousRound(semifinalRight.LocalTeam.Id, eight);
            var qfRight2 = getMatchPreviousRound(semifinalRight.VisitorTeam.Id, eight);

            qfListRight.Add(qfRight1);
            qfListRight.Add(qfRight2);

            #endregion

            #region last 16

            var last16Left = new List<MatchGeneralInfo>();

            foreach (var item in qfListLeft)
            {
                var prev1 = getMatchPreviousRound(item.LocalTeam.Id, sixteen);
                var prev2 = getMatchPreviousRound(item.VisitorTeam.Id, sixteen);

                last16Left.Add(prev1);
                last16Left.Add(prev2);
            }

            var last16Right = new List<MatchGeneralInfo>();

            foreach (var item in qfListRight)
            {
                var prev1 = getMatchPreviousRound(item.LocalTeam.Id, sixteen);
                var prev2 = getMatchPreviousRound(item.VisitorTeam.Id, sixteen);

                last16Right.Add(prev1);
                last16Right.Add(prev2);
            }

            #endregion

            return new TournamentDraw()
            {
                EightLeft = last16Left,
                EightRight = last16Right,
                QuarterFinalsLeft = qfListLeft,
                QuarterFinalsRight = qfListRight,
                SemifinalsLeft = semifinalLeft,
                SemifinalsRight = semifinalRight,
                Final = finalMatch
            };
        }

        public async Task<bool> SaveCompetitionDetails(Competition competition)
        {
            var currentCompetition = await _context.Competicion.Include(x=>x.CompetitionLogoGlobalMedia)
                .FirstOrDefaultAsync(x => x.CodCompeticion == competition.Id);

            currentCompetition.Nombre = competition.Name;
            currentCompetition.Temporada = competition.Season;
            currentCompetition.Tipo = competition.Type;

            var imageExists = await _context.GlobalMedia.FirstOrDefaultAsync(x => competition.Logo !=null && x.BlobStorageReference == competition.Logo.FileName);

            if (imageExists == null)
            {
                currentCompetition.CompetitionLogoGlobalMedia = new GlobalMedia()
                {
                    BlobStorageReference = competition.Logo.FileName,
                    FileName = competition.Logo.FileName,
                    BlobStorageContainer = "mycontainer"
                };
            }
            else
            {
                currentCompetition.CompetitionLogoGlobalMedia = imageExists;
            }

            await _context.SaveChangesAsync();

            return true;
        }

        private MatchGeneralInfo createMatchFromDb(Partido match)
        {
            return new MatchGeneralInfo()
            {
                Date = match.Fecha,
                GoalsLocal = match.GolesLocal,
                GoalsVisitor = match.GolesVisitante,
                LocalTeam = new Team()
                {
                    Id = match.CodLocal,
                    Name = match.CodLocalNavigation.Nombre,
                    PictureLogo = match.CodLocalNavigation.TeamPictureGlobalMedia != null ? new Crosscutting.BlobData()
                    {
                        ContainerReference = match.CodLocalNavigation.TeamPictureGlobalMedia.BlobStorageContainer,
                        FileName = match.CodLocalNavigation.TeamPictureGlobalMedia.BlobStorageReference
                    } : new Crosscutting.BlobData()
                },
                VisitorTeam = new Team()
                {
                    Id = match.CodVisitante,
                    Name = match.CodVisitanteNavigation.Nombre,
                    PictureLogo = match.CodVisitanteNavigation.TeamPictureGlobalMedia != null ? new Crosscutting.BlobData()
                    {
                        ContainerReference = match.CodVisitanteNavigation.TeamPictureGlobalMedia.BlobStorageContainer,
                        FileName = match.CodVisitanteNavigation.TeamPictureGlobalMedia.BlobStorageReference
                    } : new Crosscutting.BlobData()
                },
                MatchId = match.CodPartido,
                Stadium = new Stadium()
                {
                    Id = match.CodEstadio,
                    Name = match.CodEstadioNavigation.Nombre
                }
            };
        }

        private MatchGeneralInfo getMatchPreviousRound(int teamId, 
            List<MatchGeneralInfo> allGamesPreviousRound)
        {
            return allGamesPreviousRound.FirstOrDefault(x => x.LocalTeam.Id == teamId
                || x.VisitorTeam.Id == teamId);

        }
    }
}
