using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Commands.Teams
{
    public class CreateTeam : AuthenticatedCommand
    {
        public Guid Id { get; set; }

        public string TeamName { get; set; }

        public string Description { get; set; }
    }
}
