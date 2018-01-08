using Crosscutting.ViewModels;
using DataAccess.Concrete;
using DataAccess.Interface;
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

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }


        public List<Player> GetPlayers()
        {
            return _playerRepository.GetAllPlayers();
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
            return await _playerRepository.GetPlayer(playerId);
        }

        public async Task<int> UpdatePlayer(Player player)
        {
            return await _playerRepository.UpdatePlayer(player);
        }
    }
}
