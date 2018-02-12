using Football.Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Competition;
using Football.Crosscutting.ViewModels.Match;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.DataAccess.Interface
{
    public interface ICompetitionRepository
    {
        Task<List<Competition>> GetCompetitions(int? teamId = null, string season = null);

        Task<List<MatchGeneralInfo>> GetMatches(int competitionId, string round);

        Task<CompetitionRoundData> GetCompetitionRoundData(int competitionId, string round);

        Task<MatchOverview> GetMatchOverview(int matchId);

        Task<Competition> GetCompetitionById(int competitionId);

        Task<List<Scorer>> GetTopScorers(int competitionId, string round);

        Task<TournamentDraw> GetDraw(int competitionId);
    }
}
