using System;
using System.Threading.Tasks;
using Core.Domain;
using System.Collections.Generic;

namespace Core.Repositiories
{
    public interface ITeamRepository : IRepository
    {
        Task AddAsync(Team team);
        Task<Team> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(User user);
        Task<IEnumerable<Team>> BrowseAsync();
    }
}