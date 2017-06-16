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

namespace testdotnet2.Controllers
{


    public class UsersController : ApiBaseController
    {
        private readonly IUserService _userService;

        private readonly GeneralSettings _configuration;

        public UsersController(IUserService userService,
            ICommandDispatcher commandDispacher,
            GeneralSettings configuration) : base (commandDispacher) 
        {
            _configuration = configuration;
            _userService = userService;
        }

        // GET api/values
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            return Json(user);
        }

        // POST 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Created($"users/{command.Email}", new object()); //201

        }

    }
}
