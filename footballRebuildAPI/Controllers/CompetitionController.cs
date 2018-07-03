﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Football.Services.Interface;
using Football.Crosscutting.ViewModels.Competition;
using Football.Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Match;
using Football.API.Filters;
using Football.Crosscutting.ViewModels.Reports;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Football.API.Controllers
{
    [Route("api/[controller]")]
    //https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters
    //[TypeFilter(typeof(AuthorizationRequiredAttribute), Arguments = new object[] { new string[] { "Admin", "Lord" } })]
    public class CompetitionController : Controller
    {
        private readonly ICompetitionService _competitionService;
        private readonly IReportService _reportService;

        public CompetitionController(ICompetitionService competitionService, IReportService reportService)
        {
            _competitionService = competitionService;
            _reportService = reportService;
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
        public async Task<CompetitionRoundData> GetCompetitionRoundData(int competitionId, string round)
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
        [Route("{competitionId}/round/{round}/scorers")]
        public async Task<List<Scorer>> GetTopScorers(int competitionId, string round)
        {
            return await _competitionService.GetTopScorers(competitionId, round);
        }

        [HttpGet]
        [Route("{competitionId}/getDraw")]
        public async Task<TournamentDraw> GetDraw(int competitionId)
        {
            return await _competitionService.GetDraw(competitionId);
        }

        [Route("SaveCompetitionDetails")]
        [HttpPost]
        public async Task<bool> SaveCompetitionDetails([FromBody]Competition competition)
        {
            return await _competitionService.SaveCompetitionDetails(competition);
        }

        [HttpGet]
        [Route("{matchId}/getReport")]
        public async Task<List<BaseItem>> GetReport(int matchId)
        {
            return await _reportService.GenerateReport(matchId);
        }

        [HttpGet]
        [Route("{matchId}/reportSnapshot")]
        public ReportData GetReportSnapshot(int matchId)
        {
            return _reportService.GetReportSnapshot(matchId);
        }
    }
}
