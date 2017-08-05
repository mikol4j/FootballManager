using Core.Repositiories;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {

        private static ISet<Team> _teams = new HashSet<Team>
        {

        };


        public async Task AddAsync(Team team)
        {
            if(!_teams.Contains(team))
            {
                _teams.Add(team);
            }
            else
            {
                throw new Exception("team already exits");
            }

        }

        public async Task<IEnumerable<Team>> BrowseAsync()
        {
            return await Task.FromResult(_teams);
        }

        public async Task<Team> GetAsync(Guid id)
            =>_teams.SingleOrDefault(x => x.TeamId == id);


        //public async Task<User> GetAsync(string email)
        //    => _teams.SingleOrDefault(x => x.Email == email);

        public async Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
