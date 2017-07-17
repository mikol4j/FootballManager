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


    public class AccountController : ApiBaseController
    {
        private readonly IJwtHandler _jwtHandler;

        public AccountController(ICommandDispatcher commandDispacher, IJwtHandler jwtHandler) : base (commandDispacher) 
        {
            _jwtHandler = jwtHandler;
        }

        [HttpGet]
        [Route("token")]
        public IActionResult Get()
        {
            var token = _jwtHandler.CreateToken("user1@gmail.com", "user");

            return Json(token);

        }

        [HttpGet]
        [Authorize]
        [Route("auth")]
        public IActionResult GetAuth()
            => Json("ok");

        [Route("password")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return NoContent();

        }

    }
}
