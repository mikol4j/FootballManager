using Core.Domain;
using Core.Repositiories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public static class RepositoryExtensions
    {
        public static async Task<Team> GetOrFailAsync(this ITeamRepository teamRepository, Guid id)
        {
            var team = await teamRepository.GetAsync(id);
            if (team == null)
            {
                throw new Exception($"Team with userid: {id}, was not found.");
            }
            return team;
        }
    }
}
