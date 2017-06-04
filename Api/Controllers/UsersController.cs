using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.Services;
using Infrastructure.Dto;
using Infrastructure.Commands.Users;

namespace testdotnet2.Controllers
{

    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/values
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);
            if(user == null)
            {
                return NotFound();
            }
            return Json(user);
        }

        // POST 
        [HttpPost]
        public IActionResult Post([FromBody]CreateUser request)
        {

                _userService.RegisterAsync(request.Email, request.Username, request.Password);
                return Ok();

        }

    }
}
