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


    public class CourtController : ApiBaseController
    {
        private readonly IUserService _userService;
        private readonly ICourtProvider _courtProvider;

        private readonly GeneralSettings _configuration;

        public CourtController(IUserService userService,
            ICommandDispatcher commandDispacher,
            GeneralSettings configuration,
            ICourtProvider courtProvider) : base(commandDispacher)
        {
            _courtProvider = courtProvider;
            _configuration = configuration;
            _userService = userService;
        }


        public async Task<IActionResult> Get()
        {
            var courts = await _courtProvider.BrowseAsync();
            return Json(courts);
        }
        

    }
}
