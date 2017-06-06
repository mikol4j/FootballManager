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

namespace testdotnet2.Controllers
{

    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        private readonly ICommandDispatcher _commandDispacher;

        public UsersController(IUserService userService, ICommandDispatcher commandDispacher)
        {
            _userService = userService;
            _commandDispacher = commandDispacher;
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
            await _commandDispacher.DsipatchAsync(command);

            return Created($"users/{command.Email}", new object()); //201

        }

    }
}
