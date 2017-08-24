using Crosscutting.ViewModels;
using DataAccess.Concrete;
using DataAccess.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
