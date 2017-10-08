using Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Match;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IPlayerService
    {
        List<Player> GetPlayers();

        List<MatchPlayedInfo> GetMatchesPlayed(int id);

        Task<MatchPlayerStatistics> GetMatchPlayerStatistics(int playerId, int matchId);
    }
}
