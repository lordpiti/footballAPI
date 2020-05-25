using Crosscutting.ViewModels;
using DataAccess.Interface;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;
using Football.Crosscutting.ViewModels.Match;
using System.Threading.Tasks;
using Football.Crosscutting;
using Football.Crosscutting.ViewModels.Competition;

namespace DataAccess.Concrete
{
    public class PlayerRepository: EFRepositoryBase, IPlayerRepository
    {
        public PlayerRepository(c__database_futbol_mdfContext context) : base(context)
        {
        }

        public async Task<List<Player>> GetAllPlayers()
        {
            return await _context.Jugador.Include(x => x.CodIntegranteNavigation).Include(x=>x.CodEquipoNavigation).Select(x => new Player()
            {
                Name = x.CodIntegranteNavigation.Nombre,
                Surname = x.CodIntegranteNavigation.Apellidos,
                TeamName = x.CodEquipoNavigation.Nombre,
                PlayerId = x.CodJugador,
                TeamId = (int)x.CodEquipo
            }).ToListAsync();
        }

        public List<MatchPlayedInfo> GetMatchesPlayed(int id)
        {
            //https://docs.microsoft.com/en-us/ef/core/querying/related-data#related-data-and-serialization
            //https://github.com/aspnet/EntityFrameworkCore/issues/4716
            var toReturn = _context.Jugador
                .Include(x=>x.PartidoJugado)
                .ThenInclude(partidoJugado => partidoJugado.CodPartidoNavigation.CodLocalNavigation)
                .Include(x => x.PartidoJugado)
                .ThenInclude(partidoJugado => partidoJugado.CodPartidoNavigation.CodVisitanteNavigation)
                .Include(x => x.PartidoJugado)
                .ThenInclude(partidoJugado => partidoJugado.CodPartidoNavigation.CodCompeticionNavigation)
                .FirstOrDefault(x => x.CodJugador == id)
                .PartidoJugado.Select(x => new MatchPlayedInfo(){
                    Id = x.CodPartido,
                    Date = x.CodPartidoNavigation.Fecha,
                    LocalGoals = x.CodPartidoNavigation.GolesLocal,
                    VisitorGoals = x.CodPartidoNavigation.GolesVisitante,
                    RecoveredBalls = x.BalonesRecuperados,
                    LocalTeamName = x.CodPartidoNavigation.CodLocalNavigation.Nombre,
                    VisitorTeamName = x.CodPartidoNavigation.CodVisitanteNavigation.Nombre,
                    Round = x.CodPartidoNavigation.Jornada,
                    Competition = new Competition()
                    {
                        Id = x.CodPartidoNavigation.CodCompeticionNavigation.CodCompeticion,
                        Name = x.CodPartidoNavigation.CodCompeticionNavigation.Nombre,
                        Season = x.CodPartidoNavigation.CodCompeticionNavigation.Temporada,
                        Type = x.CodPartidoNavigation.CodCompeticionNavigation.Tipo
                    }
                }).ToList();

            return toReturn;
        }

        public async Task<MatchPlayerStatistics> GetMatchPlayerStatistics(int playerId, int matchId)
        {
            var dbData = await _context.PartidoJugado.FirstOrDefaultAsync(x => x.CodJugador == playerId && x.CodPartido == matchId);

            return new MatchPlayerStatistics()
            {
                Assistances = dbData.Asistencias,
                Fauls = dbData.FaltasCometidas,
                FaulsReceived = dbData.FaltasRecibidas,
                Minutes = dbData.Minutos,
                MissedBalls = dbData.BalonesPerdidos,
                RecoveredBalls = dbData.BalonesRecuperados,
                Shots = dbData.Remates,
                ShotsOnTarget = dbData.RematesPorteria
            };
        }

        public async Task<Player> GetPlayer(int playerId)
        {
            var playerFromDb = await _context.Jugador
                .Include(x=>x.CodIntegranteNavigation).ThenInclude(x=>x.Picture)
                .FirstOrDefaultAsync(x => x.CodJugador == playerId);

            return new Player()
            {
                BirthDate = playerFromDb.CodIntegranteNavigation.FechaNac,
                BirthPlace = playerFromDb.CodIntegranteNavigation.BirthPlace,
                Name = playerFromDb.CodIntegranteNavigation.Nombre,
                Position = playerFromDb.Posicion,
                Picture = playerFromDb.CodIntegranteNavigation.Picture!=null ? new BlobData() {
                    FileName = playerFromDb.CodIntegranteNavigation.Picture.BlobStorageReference,
                    ContainerReference = playerFromDb.CodIntegranteNavigation.Picture.BlobStorageContainer
                }: new BlobData() { }, Surname = playerFromDb.CodIntegranteNavigation.Apellidos,
                Height = playerFromDb.Altura,
                PlayerId = playerId
            };
        }

        public async Task<List<Player>> GetPlayersFromList(List<int> playerIdList)
        {
            var playersFromDb = await _context.Jugador.Include(x => x.CodIntegranteNavigation).Where(x => playerIdList.Any(y => x.CodJugador == y )).ToListAsync();

            return playersFromDb.Select(playerFromDb => new Player()
            {
                BirthDate = playerFromDb.CodIntegranteNavigation.FechaNac,
                Name = playerFromDb.CodIntegranteNavigation.Nombre,
                Picture = playerFromDb.CodIntegranteNavigation.Picture != null ? new BlobData()
                {
                    FileName = playerFromDb.CodIntegranteNavigation.Picture.FileName,
                    ContainerReference = playerFromDb.CodIntegranteNavigation.Picture.BlobStorageContainer
                } : new BlobData() { },
                Surname = playerFromDb.CodIntegranteNavigation.Apellidos,
                Height = playerFromDb.Altura,
                PlayerId = playerFromDb.CodJugador,
                TeamId = (int)playerFromDb.CodEquipo,
                BirthPlace = playerFromDb.CodIntegranteNavigation.BirthPlace
            }).ToList();
        }

        public async Task<int> UpdatePlayer(Player player)
        {
            try
            {
                var playerToUpdate = await _context.Jugador.Include(x => x.CodIntegranteNavigation).FirstOrDefaultAsync(x => x.CodJugador == player.PlayerId);

                playerToUpdate.CodIntegranteNavigation.Nombre = player.Name;
                playerToUpdate.CodIntegranteNavigation.Apellidos = player.Surname;
                playerToUpdate.CodIntegranteNavigation.FechaNac = player.BirthDate;
                playerToUpdate.Altura = player.Height;
                playerToUpdate.CodIntegranteNavigation.BirthPlace = player.BirthPlace;
                playerToUpdate.Posicion = player.Position??"Forward";

                var imageExists = await _context.GlobalMedia.FirstOrDefaultAsync(x => x.BlobStorageReference == player.Picture.FileName);

                if (imageExists == null)
                {
                    playerToUpdate.CodIntegranteNavigation.Picture = new GlobalMedia()
                    {
                        BlobStorageReference = player.Picture.FileName,
                        FileName = player.Picture.FileName,
                        BlobStorageContainer = "mycontainer"
                    };
                }
                else
                {
                    playerToUpdate.CodIntegranteNavigation.Picture = imageExists;
                }

                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
