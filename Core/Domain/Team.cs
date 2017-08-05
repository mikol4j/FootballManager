using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Team
    {
        public Guid TeamId { get; set; }

        public string TeamName { get; protected set; }

        public string Description { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        protected Team()
        {
            //protects from creating parameterless instance
        }

        public Team(User user)
        {
            TeamId = user.Id;
            Description = $"Team created for {user.FullName}";
        }

        public void SetTeam(string teamName, string description)
        {
               
        }
    }


}
