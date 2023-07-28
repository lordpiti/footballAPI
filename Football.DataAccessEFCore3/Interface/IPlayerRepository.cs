using Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Competition;
using Football.Crosscutting.ViewModels.Match;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.DataAccessEFCore3.Interface
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAllPlayers(int pageNumber = 1, int pageSize = 0);

        List<MatchPlayedInfo> GetMatchesPlayed(int id);

        Task<MatchPlayerStatistics> GetMatchPlayerStatistics(int playerId, int matchId);

        Task<List<Competition>> GetCompetitionsByPlayer(int id);

        Task<List<MatchPlayedInfo>> GetMatchesByCompetitionAndPlayer(int competitionId, int playerId);

        Task<Player> GetPlayer(int playerId);

        Task<int> UpdatePlayer(Player player);

        Task<List<Player>> GetPlayersFromList(IEnumerable<int> playerIdList);

        Task<int> UpdatePlayers(List<Player> players);
    }
}
