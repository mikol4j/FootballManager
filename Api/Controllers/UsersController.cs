using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.Services;
using Infrastructure.Dto;

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
        public UserDto Get(string email)
        => _userService.Get(email);

    }
}