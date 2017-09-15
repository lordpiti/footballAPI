using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Football.Services.Interface;
using Football.Crosscutting.ViewModels.Competition;

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
        [Route("season/{season}")]
        [Route("")]
        public async Task<List<Competition>> GetCompetitions(int? teamId = null, string season = null)
        {
            return await _competitionService.GetCompetitions(teamId, season);
        }
    }
}
