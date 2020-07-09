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
    public class TeamRepository : EFRepositoryBase, ITeamRepository
    {
        public TeamRepository(FootballContext context) : base(context)
        {
        }

        public async Task<Team> GetTeamByIdAndYear(int id, int year)
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

                var team = new Team()
                {
                    Id = id,
                    Name = teamFromBD.Nombre,
                    City = teamFromBD.Localidad,
                    Stadium = new Stadium()
                    {
                        Address = teamFromBD.CodEstadioNavigation.Direccion,
                        Id = teamFromBD.CodEstadioNavigation.CodEstadio,
                        Name = teamFromBD.CodEstadioNavigation.Nombre,
                        Capacity = teamFromBD.CodEstadioNavigation.Capacidad
                    },
                    PictureLogo = teamFromBD.TeamPictureGlobalMedia != null ? new BlobData()
                    {
                        ContainerReference = teamFromBD.TeamPictureGlobalMedia.BlobStorageContainer,
                        FileName = teamFromBD.TeamPictureGlobalMedia.BlobStorageReference
                    } : new BlobData() { },
                    PlayerList = teamFromBD.Jugador.Where(x => x.CodIntegranteNavigation.HcoIntegrante.Any(hco => hco.FechaInicio.Year == year))
                    .Select(x => new Player()
                    {
                        Name = x.CodIntegranteNavigation.Nombre,
                        Surname = x.CodIntegranteNavigation.Apellidos,
                        TeamName = teamFromBD.Nombre,
                        BirthDate = x.CodIntegranteNavigation.FechaNac,
                        Position = x.Posicion,
                        BirthPlace = x.CodIntegranteNavigation.BirthPlace,
                        Height = x.Altura,
                        PlayerId = x.CodJugador,
                        Dorsal = x.CodIntegranteNavigation.HcoIntegrante.FirstOrDefault(hco =>hco.FechaInicio.Year == year).Dorsal,
                        Picture = x.CodIntegranteNavigation.PictureGlobalMedia != null ? new BlobData()
                        {
                            ContainerReference = x.CodIntegranteNavigation.PictureGlobalMedia.BlobStorageContainer,
                            FileName = x.CodIntegranteNavigation.PictureGlobalMedia.BlobStorageReference
                        } : new BlobData() { },
                    }).ToList()
                };

                return team;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Team>> GetAllTeams(int? competitionId = null)
        {
            if (competitionId != null)
            {
                return await _context.EquiposParticipan.Where(x=>x.CodCompeticion == competitionId)
                    .Include(x => x.CodEquipoNavigation)
                    .Select(x => new Team()
                    {
                        Id = x.CodEquipoNavigation.CodEquipo,
                        Name = x.CodEquipoNavigation.Nombre,
                        PictureLogo = new BlobData()
                        {
                            FileName = x.CodEquipoNavigation.TeamPictureGlobalMedia.BlobStorageReference,
                            ContainerReference = x.CodEquipoNavigation.TeamPictureGlobalMedia.BlobStorageContainer
                        }
                    }).ToListAsync();
            }

            return await _context.Equipo.Include(x=>x.TeamPictureGlobalMedia).Select(equipo => new Team()
            {
                Id = equipo.CodEquipo,
                Name = equipo.Nombre,
                PictureLogo = new BlobData()
                {
                    FileName = equipo.TeamPictureGlobalMedia.BlobStorageReference,
                    ContainerReference = equipo.TeamPictureGlobalMedia.BlobStorageContainer
                }
            }).ToListAsync();
        }

        public async Task AddTeamPicture(int teamId, BlobData mediaItem)
        {
            var team = await _context.Equipo.FirstOrDefaultAsync(x => x.CodEquipo == teamId);

            team.TeamPictureGlobalMedia = new GlobalMedia()
            {
                BlobStorageContainer = "mycontainer",
                BlobStorageReference = mediaItem.FileName,
                FileName = mediaItem.FileName
            };

            await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateTeam(Team team)
        {
            try
            {
                var existingteam = await _context.Equipo.FirstOrDefaultAsync(x => x.CodEquipo == team.Id);

                existingteam.Nombre = team.Name;
                existingteam.Localidad = team.City;

                var imageExists = await _context.GlobalMedia.FirstOrDefaultAsync(x => x.BlobStorageReference == team.PictureLogo.FileName);

                if (imageExists == null)
                {
                    existingteam.TeamPictureGlobalMedia = new GlobalMedia()
                    {
                        BlobStorageReference = team.PictureLogo.FileName,
                        FileName = team.PictureLogo.FileName,
                        BlobStorageContainer = "mycontainer"
                    };
                }
                else
                {
                    existingteam.TeamPictureGlobalMedia = imageExists;
                }

                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClasificationChartData> GetTeamSeasonClasificationChartData(int teamId, 
            string competitionName, string season)
        {
            var clasificationSeasonData = await _context.Clasificacion.Include(x => x.CodCompeticionNavigation)
                .Where(x => x.CodEquipo == teamId 
                && x.CodCompeticionNavigation.Temporada == season 
                && x.CodCompeticionNavigation.Nombre == competitionName).Select(x=>new ClasificationRoundData()
                {
                    Position = x.Posicion,
                    GoalsAgainst = x.GolesContra,
                    GoalsFor = x.GolesFavor,
                    Round = x.Jornada
                })
                .OrderBy(x=>x.Round).ToListAsync();

            var team = await _context.Equipo.FirstOrDefaultAsync(x => x.CodEquipo == teamId);

            return new ClasificationChartData()
            {
                Season = season,
                TeamName = team.Nombre,
                ClasificationSeasonData = clasificationSeasonData
            };
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
