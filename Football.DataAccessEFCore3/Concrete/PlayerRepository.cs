﻿using Crosscutting.ViewModels;
using Football.DataAccessEFCore3.Interface;
using Football.DataAccessEFCore3.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;
using Football.Crosscutting.ViewModels.Match;
using System.Threading.Tasks;
using Football.Crosscutting;
using Football.Crosscutting.ViewModels.Competition;

namespace Football.DataAccessEFCore3.Concrete
{
    public class PlayerRepository: EFRepositoryBase<Jugador>, IPlayerRepository
    {
        public PlayerRepository(FootballContext context) : base(context)
        {
        }

        public async Task<List<Player>> GetAllPlayers(int pageNumber = 1, int pageSize = 0)
        {
            var query = _context.Jugador
                .Include(x => x.CodIntegranteNavigation)
                .Include(x => x.CodEquipoNavigation)
                .Select(x => new Player()
                {
                    Name = x.CodIntegranteNavigation.Nombre,
                    Surname = x.CodIntegranteNavigation.Apellidos,
                    TeamName = x.CodEquipoNavigation.Nombre,
                    PlayerId = x.CodJugador,
                    TeamId = (int)x.CodEquipo,
                    Position = x.Posicion,
                    PositionCode = x.Position
                });

            if (pageSize > 0 && pageNumber > 0)
            {
                query = query
                    .Skip(pageSize * (pageNumber -1))
                    .Take(pageSize);
            }

            return await query.ToListAsync();
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

        public async Task<List<Competition>> GetCompetitionsByPlayer(int id)
        {
            var result = await _context.PartidoJugado.Where(x => x.CodJugador == id)
                .Include(x => x.CodPartidoNavigation)
                .ThenInclude(x => x.CodCompeticionNavigation)
                .Select(x => new Competition()
                {
                    Id = x.CodPartidoNavigation.CodCompeticionNavigation.CodCompeticion,
                    Name = x.CodPartidoNavigation.CodCompeticionNavigation.Nombre,
                    Season = x.CodPartidoNavigation.CodCompeticionNavigation.Temporada,
                    Type = x.CodPartidoNavigation.CodCompeticionNavigation.Tipo
                }).Distinct()
                .ToListAsync();

            return result;
        }

        public async Task<List<MatchPlayedInfo>> GetMatchesByCompetitionAndPlayer(int competitionId, int playerId)
        {
            var result = await _context.PartidoJugado.Where(x => x.CodJugador == playerId)
                .Include(x => x.CodPartidoNavigation).ThenInclude(x => x.CodCompeticionNavigation)
                .Include(x => x.CodPartidoNavigation).ThenInclude(x => x.CodLocalNavigation)
                .Include(x => x.CodPartidoNavigation).ThenInclude(x => x.CodVisitanteNavigation)
                .Where(x => x.CodPartidoNavigation.CodCompeticionNavigation.CodCompeticion == competitionId)
                .Select(x => new MatchPlayedInfo()
                {
                    Id = x.CodPartido,
                    Date = x.CodPartidoNavigation.Fecha,
                    LocalGoals = x.CodPartidoNavigation.GolesLocal,
                    VisitorGoals = x.CodPartidoNavigation.GolesVisitante,
                    RecoveredBalls = x.BalonesRecuperados,
                    LocalTeamName = x.CodPartidoNavigation.CodLocalNavigation.Nombre,
                    VisitorTeamName = x.CodPartidoNavigation.CodVisitanteNavigation.Nombre,
                    Round = x.CodPartidoNavigation.Jornada,
                }).ToListAsync();

            return result;
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
                .Include(x=>x.CodIntegranteNavigation).ThenInclude(x=>x.PictureGlobalMedia)
                .FirstOrDefaultAsync(x => x.CodJugador == playerId);

            return new Player()
            {
                BirthDate = playerFromDb.CodIntegranteNavigation.FechaNac,
                BirthPlace = playerFromDb.CodIntegranteNavigation.BirthPlace,
                Name = playerFromDb.CodIntegranteNavigation.Nombre,
                Position = playerFromDb.Posicion,
                Picture = playerFromDb.CodIntegranteNavigation.PictureGlobalMedia != null ? new BlobData() {
                    FileName = playerFromDb.CodIntegranteNavigation.PictureGlobalMedia.FileName,
                    BlobStorageReference = playerFromDb.CodIntegranteNavigation.PictureGlobalMedia.BlobStorageReference,
                    ContainerReference = playerFromDb.CodIntegranteNavigation.PictureGlobalMedia.BlobStorageContainer
                }: new BlobData() { }, Surname = playerFromDb.CodIntegranteNavigation.Apellidos,
                Height = playerFromDb.Altura,
                PlayerId = playerId
            };
        }

        public async Task<List<Player>> GetPlayersFromList(IEnumerable<int> playerIdList)
        {
            var playersFromDb = await _context.Jugador.Include(x => x.CodIntegranteNavigation).Where(x => playerIdList.Any(y => x.CodJugador == y )).ToListAsync();

            return playersFromDb.Select(playerFromDb => new Player()
            {
                BirthDate = playerFromDb.CodIntegranteNavigation.FechaNac,
                Name = playerFromDb.CodIntegranteNavigation.Nombre,
                Picture = playerFromDb.CodIntegranteNavigation.PictureGlobalMedia != null ? new BlobData()
                {
                    FileName = playerFromDb.CodIntegranteNavigation.PictureGlobalMedia.FileName,
                    BlobStorageReference = playerFromDb.CodIntegranteNavigation.PictureGlobalMedia.BlobStorageReference,
                    ContainerReference = playerFromDb.CodIntegranteNavigation.PictureGlobalMedia.BlobStorageContainer
                } : new BlobData() { },
                Surname = playerFromDb.CodIntegranteNavigation.Apellidos,
                Height = playerFromDb.Altura,
                PlayerId = playerFromDb.CodJugador,
                TeamId = (int)playerFromDb.CodEquipo,
                BirthPlace = playerFromDb.CodIntegranteNavigation.BirthPlace,
                PositionCode = playerFromDb.Position
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

                var imageExists = await _context.GlobalMedia.FirstOrDefaultAsync(x => x.BlobStorageReference == player.Picture.BlobStorageReference);

                if (imageExists == null)
                {
                    playerToUpdate.CodIntegranteNavigation.PictureGlobalMedia = new GlobalMedia()
                    {
                        BlobStorageReference = player.Picture.BlobStorageReference,
                        FileName = player.Picture.FileName,
                        BlobStorageContainer = "mycontainer"
                    };
                }
                else
                {
                    playerToUpdate.CodIntegranteNavigation.PictureGlobalMedia = imageExists;
                }

                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdatePlayers(List<Player> players)
        {
            try
            {
                foreach (var player in players)
                {
                    var playerToUpdate = await _context.Jugador.Include(x => x.CodIntegranteNavigation).FirstOrDefaultAsync(x => x.CodJugador == player.PlayerId);

                    playerToUpdate.Position = player.PositionCode;
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
