using Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Match;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IPlayerRepository
    {
        List<Player> GetAllPlayers();

        List<MatchPlayedInfo> GetMatchesPlayed(int id);

        Task<MatchPlayerStatistics> GetMatchPlayerStatistics(int playerId, int matchId);

        Task<Player> GetPlayer(int playerId);

        Task<int> UpdatePlayer(Player player);
    }
}
