using Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Match;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.DataAccessEFCore3.Interface
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAllPlayers();

        List<MatchPlayedInfo> GetMatchesPlayed(int id);

        Task<MatchPlayerStatistics> GetMatchPlayerStatistics(int playerId, int matchId);

        Task<Player> GetPlayer(int playerId);

        Task<int> UpdatePlayer(Player player);

        Task<List<Player>> GetPlayersFromList(IEnumerable<int> playerIdList);

        Task<int> UpdatePlayers(List<Player> players);
    }
}
