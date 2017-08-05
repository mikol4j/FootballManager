using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ITeamService : IService
    {
        Task<TeamDto> GetAsync(Guid id);

        Task CreateAsync(Guid id);

        Task SetTeam(Guid id, string teamName, string description);

        Task<IEnumerable<TeamDto>> BrowseAsync();
    }
}
