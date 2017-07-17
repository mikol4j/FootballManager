using Infrastructure.Commands;
using Infrastructure.Commands.Users;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HadnleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(command.Email, command.Username, command.Password, "");
        }
    }
}
