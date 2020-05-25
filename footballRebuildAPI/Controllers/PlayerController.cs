using AspNetCoreSignalr.SignalRHubs;
using Crosscutting.ViewModels;
using Football.API.Filters;
using Football.Crosscutting.ViewModels.Match;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace footballRebuildAPI.Controllers
{
    //https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing

    [Route("api/[controller]")]
    //[ServiceFilter(typeof(AuthorizationRequiredAttribute))]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService, IHubContext<LoopyHub> context)
        {
            _playerService = playerService;
        }
        
        [HttpGet]
        [Route("MatchesPlayed/{id}")]
        public IEnumerable<MatchPlayedInfo> GetMatchesPlayed(int id)
        {
            return _playerService.GetMatchesPlayed(id);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Player>> List()
        {
            return await _playerService.GetPlayers();
        }

        [HttpGet]
        [Route("{playerId}/MatchPlayedStatistics/{matchId}")]
        public async Task<MatchPlayerStatistics> MatchPlayerStatistics(int playerId, int matchId)
        {
            return await _playerService.GetMatchPlayerStatistics(playerId, matchId);
        }

        [HttpGet]
        [Route("{playerId}")]
        public async Task<Player> GetPlayer(int playerId)
        {
            return await _playerService.GetPlayer(playerId);
        }

        [HttpPost]
        [Route("savePlayerDetails")]
        [TypeFilter(typeof(AuthorizationRequiredAttribute), Arguments = new object[] { new string[] { "Admin", "Lord" } })]
        public async Task<int> UpdatePlayer([FromBody]Player playerDetails)
        {
            return await _playerService.UpdatePlayer(playerDetails);
        }
    }
}
