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

        public AccountController(ICommandDispatcher commandDispacher) : base (commandDispacher) 
        {
        }


        // POST 
        [Route("password")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return NoContent();

        }

    }
}
