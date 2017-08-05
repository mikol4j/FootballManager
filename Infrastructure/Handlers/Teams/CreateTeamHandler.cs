using Infrastructure.Commands;
using Infrastructure.Commands.Teams;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.Teams
{
    public class CreateTeamHandler : ICommandHandler<CreateTeam>
    {
        private readonly ITeamService _teamService;
        public CreateTeamHandler(ITeamService teamService)
        {
            ITeamService _teamService = teamService;
        }
        public async Task HadnleAsync(CreateTeam command)
        {
            await _teamService.CreateAsync(command.Id);
            await _teamService.SetTeam(command.Id, command.TeamName, command.Description);

        }
    }
}
