using Crosscutting.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interface
{
    public interface IPlayerService
    {
        List<Player> GetPlayers();

        List<MatchPlayedInfo> GetMatchesPlayed(int id);
    }
}
