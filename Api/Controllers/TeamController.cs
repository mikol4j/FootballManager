using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.Services;
using Infrastructure.Dto;
using Infrastructure.Commands.Users;
using Infrastructure.Commands;
using Microsoft.Extensions.Configuration;
using Infrastructure.Settings;
using Infrastructure.Commands.Teams;

namespace testdotnet2.Controllers
{


    public class TeamController : ApiBaseController
    {
        private readonly ITeamService _teamService;

        public TeamController(IUserService userService,
            ICommandDispatcher commandDispacher, ITeamService teamService) : base (commandDispacher) 
        {
            ITeamService _teamService = teamService;
        }
        // GET
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teams = await _teamService.BrowseAsync();

            return Json(teams);
        }
        // POST 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateTeam command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return NoContent();
        }

    }
}
