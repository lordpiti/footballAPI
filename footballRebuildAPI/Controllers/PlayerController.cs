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
        public Team GetTeam(int id, int year)
        {
            return _teamService.GetTeamByIdAndYear(id, year);
        }

        [HttpGet]
        [Route("Teams")]
        public List<Team> GetAllTeams()
        {
            return _teamService.GetAllTeams();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
