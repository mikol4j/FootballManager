using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto
{
    public class TeamDto
    {
        public Guid Id { get; set; }

        public string TeamName { get;  set; }

        public string Description { get; set; }

    }
}
