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

namespace footballRebuildAPI.Controllers
{
    //https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing

    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
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

    }
}
