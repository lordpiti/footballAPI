using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Football.Services.Interface;
using Football.Crosscutting.ViewModels.Competition;
using Football.Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Match;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Football.API.Controllers
{
    [Route("api/[controller]")]
    public class CompetitionController : Controller
    {
        private readonly ICompetitionService _competitionService;

        public CompetitionController(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        [HttpGet]
        [Route("team/{teamId?}/season/{season}")]
        [Route("team/{teamId?}")]
        [Route("season/{season}")]
        [Route("")]
        public async Task<List<Competition>> GetCompetitions(int? teamId = null, string season = null)
        {
            return await _competitionService.GetCompetitions(teamId, season);
        }

        [HttpGet]
        [Route("{competitionId}/round/{round}")]
        public async Task<CompetitionRoundData> GetMatches(int competitionId, string round)
        {
            return await _competitionService.GetCompetitionRoundData(competitionId, round);
        }

        [HttpGet]
        [Route("match/{matchId}")]
        public async Task<MatchOverview> GetMatchOverview(int matchId)
        {
            return await _competitionService.GetMatchOverview(matchId);
        }

        [HttpGet]
        [Route("{competitionId}")]
        public async Task<Competition> GetCompetitionById(int competitionId)
        {
            return await _competitionService.GetCompetitionById(competitionId);
        }

        [HttpGet]
        [Route("{competitionId}/scorers")]
        public async Task<object> GetTopScorers(int competitionId)
        {
            return await _competitionService.GetTopScorers(competitionId);
        }
    }
}
