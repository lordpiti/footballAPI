using Crosscutting.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interface
{
    public interface IPlayerRepository
    {
        List<Player> GetAllPlayers();

        List<MatchPlayedInfo> GetMatchesPlayed(int id);
    }
}
