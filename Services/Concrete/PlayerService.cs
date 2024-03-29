﻿using Crosscutting.ViewModels;
using Football.BlobStorage.Interfaces;
using Football.Crosscutting.ViewModels.Competition;
using Football.Crosscutting.ViewModels.Match;
using Football.DataAccessEFCore3.Interface;
using Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IBlobStorageService _blobStorageService;

        public PlayerService(IPlayerRepository playerRepository, IBlobStorageService blobStorageService)
        {
            _playerRepository = playerRepository;
            _blobStorageService = blobStorageService;
        }


        public async Task<List<Player>> GetPlayers(int skip, int take)
        {
            return await _playerRepository.GetAllPlayers(skip, take);
        }

        public List<MatchPlayedInfo> GetMatchesPlayed(int id )
        {
            return _playerRepository.GetMatchesPlayed(id);
        }

        public async Task<MatchPlayerStatistics> GetMatchPlayerStatistics(int playerId, int matchId)
        {
            return await _playerRepository.GetMatchPlayerStatistics(playerId, matchId);
        }

        public async Task<List<Competition>> GetCompetitionsByPlayer(int id)
        {
            return await _playerRepository.GetCompetitionsByPlayer(id);
        }

        public async Task<List<MatchPlayedInfo>> GetMatchesByCompetitionAndPlayer(int competitionId, int playerId)
        {
            return await _playerRepository.GetMatchesByCompetitionAndPlayer(competitionId, playerId);
        }

        public async Task<Player> GetPlayer(int playerId)
        {
            var player = await _playerRepository.GetPlayer(playerId);

            if (player != null)
            {
                _blobStorageService.PopulateUrlForBlob(player.Picture);
            }

            return player;
        }

        public async Task<int> UpdatePlayer(Player player)
        {
            return await _playerRepository.UpdatePlayer(player);
        }

        public async Task<List<Player>> GetPlayersFromList(List<int> playerIdList)
        {
            return await _playerRepository.GetPlayersFromList(playerIdList);
        }

        public async Task<int> UpdatePlayers(List<Player> players)
        {
            return await _playerRepository.UpdatePlayers(players);
        }
    }
}
