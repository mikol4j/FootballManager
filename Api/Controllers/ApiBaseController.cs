using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.Commands;

namespace testdotnet2.Controllers
{
    [Route("[controller]")]
    public abstract class ApiBaseController : Controller
    {
        protected readonly ICommandDispatcher _commandDispatcher;

        public ApiBaseController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }
    }
}
