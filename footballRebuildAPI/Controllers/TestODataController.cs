﻿using Football.Crosscutting.ViewModels;
using Football.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Football.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]

    //Notice that an OData controller WON'T appear on the Swagger documentation
    public class TestODataController : ODataController
    {
        //IOptions<AppSettings> settings
        private readonly ITeamService _teamService;

        public TestODataController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        [Route("Teams/{competitionId?}")]
        [EnableQuery]
        public async Task<IEnumerable<Team>> GetAllTeams(int? competitionId = null)
        {
            //api/TestOData/teams?$filter=Id%20eq%201
            return await _teamService.GetAllTeams(competitionId);
        }

    }
}
