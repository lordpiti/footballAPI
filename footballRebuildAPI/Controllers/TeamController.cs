using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Football.Crosscutting.ViewModels.Teams;
using Football.Services.Interface;
using Football.Crosscutting.ViewModels;
using Football.Crosscutting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Football.API.Controllers
{
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        //IOptions<AppSettings> settings
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        [Route("Teams/{id}/year/{year}")]
        public async Task<Team> GetTeam(int id, int year)
        {
            return await _teamService.GetTeamByIdAndYear(id, year);
        }

        [HttpGet]
        [Route("Teams/{competitionId?}")]
        public async Task<List<Team>> GetAllTeams(int? competitionId=null)
        {
            return await _teamService.GetAllTeams(competitionId);
        }

        [Route("SaveTeamDetails")]
        public async Task<int> SaveTeamDetails([FromBody]Team teamDetails)
        {
            return await _teamService.UpdateTeam(teamDetails);
        }

        [Route("Clasification/{teamId}/competition/{competitionName}/season/{season}")]
        [HttpGet]
        public async Task<ClasificationChartData> GetTeamSeasonClasificationChartData(int teamId,
            string competitionName, string season)
        {
            return await _teamService.GetTeamSeasonClasificationChartData(teamId, competitionName, season);
        }
    }
}
