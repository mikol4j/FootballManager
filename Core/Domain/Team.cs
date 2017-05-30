using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Team
    {
        public Guid Id { get; set; }

        public string TeamName { get; protected set; }

        public string Description { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        protected Team()
        {
            //protects from creating parameterless instance
        }

        public Team(string teamName, string description)
        {
            Id = new Guid();
            TeamName = teamName;
            Description = description;
            CreatedAt = DateTime.UtcNow;
        }
    }


}
