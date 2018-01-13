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
using Microsoft.Extensions.Options;
using Football.Crosscutting.ViewModels.Teams;
using Football.Crosscutting.ViewModels.Match;
using Football.API.Filters;
using Microsoft.AspNetCore.SignalR;
using AspNetCoreSignalr.SignalRHubs;

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
        public IEnumerable<Player> List()
        {
            return _playerService.GetPlayers();
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
        public async Task<int> UpdatePlayer([FromBody]Player playerDetails)
        {
            return await _playerService.UpdatePlayer(playerDetails);
        }
    }
}
