using Infrastructure.Commands;
using Infrastructure.Commands.Teams;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.Teams
{
    public class CreateTeamHandler : ICommandHandler<CreateTeam>
    {
        public async Task HadnleAsync(CreateTeam command)
        {
            throw new NotImplementedException();
        }
    }
}
