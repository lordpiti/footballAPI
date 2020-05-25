using Crosscutting.ViewModels;
using DataAccess.Interface;
using Football.BlobStorage.Interfaces;
using Football.Crosscutting.ViewModels.Match;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
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


        public async Task<List<Player>> GetPlayers()
        {
            return await _playerRepository.GetAllPlayers();
        }

        public List<MatchPlayedInfo> GetMatchesPlayed(int id )
        {
            return _playerRepository.GetMatchesPlayed(id);
        }

        public async Task<MatchPlayerStatistics> GetMatchPlayerStatistics(int playerId, int matchId)
        {
            return await _playerRepository.GetMatchPlayerStatistics(playerId, matchId);
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
    }
}
