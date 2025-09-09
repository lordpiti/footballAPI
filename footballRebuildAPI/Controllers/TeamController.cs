using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Football.Crosscutting.ViewModels.Teams;
using Football.Services.Interface;
using Football.Crosscutting.ViewModels;
using Futbol.Model.FachadaPartidos;
using Football.Crosscutting.ViewModels.TopSquad;
using Crosscutting.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Football.API.Controllers
{
    [Route("api/[controller]")]

    public class TeamController : ControllerBase
    {
        //IOptions<AppSettings> settings
        private readonly ITeamService _teamService;
        private readonly ITopSquadService _topSquadService;

        public TeamController(ITeamService teamService, ITopSquadService topSquadService)
        {
            _teamService = teamService;
            _topSquadService = topSquadService;
        }

        [HttpGet]
        [Route("Teams/{id}/year/{year}")]
        public async Task<Team> GetTeam(int id, int year)
        {
            return await _teamService.GetTeamByIdAndYear(id, year);
        }

        [HttpGet]
        [Route("Teams/{competitionId?}")]
        public async Task<ActionResult<IEnumerable<Team>>> GetAllTeams(int? competitionId=null)
        {
            //api/Team/teams?$filter=Id%20eq%201
            //return await _teamService.GetAllTeams(competitionId);
            try
            {
                var teams = await _teamService.GetAllTeams(competitionId);

                if (teams == null || !teams.Any())
                {
                    return NotFound("No teams found.");
                }

                return Ok(teams); // 200 OK with data
            }
            catch (Exception ex)
            {
                // Log the exception
                // _logger.LogError(ex, "Error retrieving teams.");
                Console.WriteLine(ex);
                return Ok(new List<Team>());
            }
        }

        [Route("SaveTeamDetails")]
        [HttpPost]
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

        [Route("Clasification/{teamId}/competition/{competitionId}")]
        [HttpGet]
        public async Task<ClasificationChartData> GetTeamSeasonClasificationChartData(int teamId,
            int competitionId)
        {
            return await _teamService.GetTeamSeasonClasificationChartData(teamId, competitionId);
        }

        [Route("TopSquad")]
        [HttpGet]
        public async Task<IEnumerable<Player>> GetTopSquad()
        {
            var topSquad = await _topSquadService.GetTopSquad();
            return topSquad;
        }
    }
}
