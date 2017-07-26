using Infrastructure.Commands;
using Infrastructure.Commands.Users;
using Infrastructure.Extensions;
using Infrastructure.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.Users
{
    class LoginHandler : ICommandHandler<Login>
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _memoryCache;
        public LoginHandler(IUserService userService, IJwtHandler jwtHandler, IMemoryCache memoryCache)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
            _memoryCache = memoryCache;
        }
        public async Task HadnleAsync(Login command)
        {
            await _userService.LoginAsync(command.Email, command.Password);
            var user = await _userService.GetAsync(command.Email);
            var jwt = _jwtHandler.CreateToken(command.Email, user.Role);
            _memoryCache.SetJwt(command.TokenId, jwt);
        }
    }
}
