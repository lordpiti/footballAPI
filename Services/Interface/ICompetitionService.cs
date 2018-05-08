using Football.Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Competition;
using Football.Crosscutting.ViewModels.Match;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services.Interface
{
    public interface ICompetitionService
    {
        Task<List<Competition>> GetCompetitions(int? teamId = null, string season = null);

        Task<CompetitionRoundData> GetCompetitionRoundData(int competitionId, string round);

        Task<MatchOverview> GetMatchOverview(int matchId);

        Task<Competition> GetCompetitionById(int competitionId);

        Task<List<Scorer>> GetTopScorers(int competitionId, string round);

        Task<TournamentDraw> GetDraw(int competitionId);

        Task<bool> SaveCompetitionDetails(Competition competition);
    }
}
