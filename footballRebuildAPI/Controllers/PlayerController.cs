using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Concrete;
using Crosscutting.ViewModels;
using Services.Interface;
using Football.Services.Interface;
using Football.Crosscutting.ViewModels;
using Football.Crosscutting;
using Football.BlobStorage;

namespace footballRebuildAPI.Controllers
{
    //https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing

    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;

        public PlayerController(IPlayerService playerService, ITeamService teamService)
        {
            _playerService = playerService;
            _teamService = teamService;
        }
        
        [HttpGet]
        [Route("MatchesPlayed/{id}")]
        public IEnumerable<MatchPlayedInfo> GetMatchesPlayed(int id)
        {
            return _playerService.GetMatchesPlayed(id);
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Player> List()
        {
            return _playerService.GetPlayers();
        }

        [HttpGet]
        [Route("Teams/{id}/year/{year}")]
        public async Task<Team> GetTeam(int id, int year)
        {
            return await _teamService.GetTeamByIdAndYear(id, year);
        }

        [HttpGet]
        [Route("Teams")]
        public async Task<List<Team>> GetAllTeams()
        {
            return await _teamService.GetAllTeams();
        }


        [Route("UpdateTeamPicture/{teamId}")]
        public void AddTeamPicture(int teamId, [FromBody]BlobData mediaItem)
        {
            _teamService.AddTeamPicture(teamId, mediaItem);
        }

        [Route("SaveTeamDetails")]
        public async Task<int> SaveTeamDetails([FromBody]Team teamDetails)
        {
            return await _teamService.UpdateTeam(teamDetails);
        }
    }
}
