using Infrastructure.Commands;
using Infrastructure.Commands.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        public async Task HadnleAsync(ChangeUserPassword command)
        {
            await Task.CompletedTask;
        }
    }
}
