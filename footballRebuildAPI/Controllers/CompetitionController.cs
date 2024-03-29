﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Football.Services.Interface;
using Football.Crosscutting.ViewModels.Competition;
using Football.Crosscutting.ViewModels;
using Football.Crosscutting.ViewModels.Match;
using Football.Crosscutting.ViewModels.Reports;
using Football.API.Cache;
using FluentValidation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Football.API.Controllers
{
    /// <summary>
    /// Competition methods
    /// </summary>
    [Route("api/[controller]")]
    //https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters
    //[TypeFilter(typeof(AuthorizationRequiredAttribute), Arguments = new object[] { new string[] { "Admin", "Lord" } })]
    public class CompetitionController : Controller
    {
        private readonly ICompetitionService _competitionService;
        private readonly IReportService _reportService;
        private readonly IValidator<Competition> _validator;

        public CompetitionController(ICompetitionService competitionService, IReportService reportService, IValidator<Competition> competitionValidator)
        {
            _competitionService = competitionService;
            _reportService = reportService;
            _validator = competitionValidator;
        }

        /// <summary>
        /// Get all competitions where a team has participated
        /// </summary>
        /// <param name="teamId">Team Id</param>
        /// <param name="season">Season when the competition was played</param>
        /// <returns></returns>
        [HttpGet]
        [Route("team/{teamId?}/season/{season}")]
        [Route("team/{teamId?}")]
        [Route("season/{season}")]
        [Route("")]
        public async Task<List<Competition>> GetCompetitions(int? teamId = null, string season = null)
        {
            return await _competitionService.GetCompetitions(teamId, season);
        }

        /// <summary>
        /// Get info about an specific round in a competition
        /// </summary>
        /// <param name="competitionId">Competition Id</param>
        /// <param name="round">Round within the competition</param>
        /// <returns></returns>
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

        /// <summary>
        /// Get a list with the top scorers on a competition in a specific round
        /// </summary>
        /// <param name="competitionId">Competition Id</param>
        /// <param name="round">Round</param>
        /// <returns></returns>
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
        public async Task<ActionResult> SaveCompetitionDetails([FromBody]Competition competition)
        {
            var validationResult = _validator.Validate(competition);

            if (validationResult.IsValid)
            {
                var result = await _competitionService.SaveCompetitionDetails(competition);
                return Ok(result);
            }
            else
            {
                var errors = validationResult.Errors.Select(e => new Error(e.PropertyName, e.ErrorMessage));
                return BadRequest(errors);
            }
        }

        /// <summary>
        /// Get the next datetime for a simulation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("nextSimulation")]
        public Object GetNextSimulationDateTime()
        {
            var nextSimulationDateTime = MemoryCacher.getDateTime();
            var live = MemoryCacher.getLive();
            var secondsLeft = (int) (nextSimulationDateTime!=null ? ((TimeSpan)(nextSimulationDateTime - DateTime.Now)).TotalSeconds : 0);
            return new {
                nextSimulationDateTime,
                secondsLeft,
                live
            };
        }

        [HttpGet]
        [Route("{matchId}/getReport")]
        public async Task<ReportData> GetReport(int matchId)
        {
            return await _reportService.GenerateReport(matchId);
        }

        //[HttpGet]
        //[Route("{matchId}/reportSnapshot")]
        //public async Task<FileStreamResult> GetReportSnapshot(int matchId)
        //{
        //    var reporSnapshotData = _reportService.GetReportSnapshot(matchId);

        //    if (reporSnapshotData == null)
        //    {
        //        reporSnapshotData = await _reportService.GenerateReport(matchId);
        //    }

        //    var ms = await this._pdfGeneratorService.GenerateMatchReportPDF(reporSnapshotData);

        //    ms = new MemoryStream(ms.ToArray());

        //    return File(ms, System.Net.Mime.MediaTypeNames.Application.Octet, "MatchReport.pdf");
        //}
    }

    public record Error(string Code, string Description);
}
