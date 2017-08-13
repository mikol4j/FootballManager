using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.Commands;
using Microsoft.Extensions.Caching.Memory;
using Infrastructure.Commands.Users;
using Infrastructure.Extensions;

namespace testdotnet2.Controllers
{

    public abstract class LoginController : ApiBaseController
    {
        protected readonly IMemoryCache _memoryCache;

        public LoginController(ICommandDispatcher commandDispatcher,IMemoryCache memoryCache) : base(commandDispatcher)
        {
            _memoryCache = memoryCache;
        }

        public async Task<IActionResult> Post([FromBody] Login command)
        {
            command.TokenId = Guid.NewGuid();
            await DispatchAsync(command);
            var jwt = _memoryCache.GetJwt(command.TokenId);
            return Json(jwt);
        }
    }
} 
