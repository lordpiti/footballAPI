using Football.Crosscutting.ViewModels.Competition;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Football.Services.Interface
{
    public interface ICompetitionService
    {
        Task<List<Competition>> GetCompetitions(int? teamId = null, string season = null);

        Task<List<MatchGeneralInfo>> GetMatches(int competitionId, string round);
    }
}
