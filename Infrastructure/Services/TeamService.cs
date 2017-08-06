using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Dto;
using Core.Repositiories;
using AutoMapper;
using Core.Domain;

namespace Infrastructure.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICourtProvider _courtProvider;
        private readonly IMapper _mapperRepository;

        public TeamService(ITeamRepository teamRepository, IUserRepository 
            userRepository, IMapper mapper, ICourtProvider courtProvider)
        {
            _teamRepository = teamRepository;
            _mapperRepository = mapper;
            _userRepository = userRepository;
            _courtProvider = courtProvider;
        }


        public async Task<TeamDto> GetAsync(Guid id)
        {
            var team = await _teamRepository.GetAsync(id);
            return _mapperRepository.Map<Team, TeamDto>(team);
        }

        public async Task CreateAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            if(user == null)
            {
                throw new Exception($"User with userid: {id}, was not found.");
            }
            var team = await _teamRepository.GetAsync(id);
            if (team != null)
            {
                throw new Exception($"Team with userid: {id}, already exists.");
            }

            team = new Team(user);
            await _teamRepository.AddAsync(team);
        }

        public async Task SetTeam(Guid id, string teamName, string description)
        {
            var team = await _teamRepository.GetAsync(id);
            if (team == null)
            {
                throw new Exception($"Team with userid: {id}, was not found.");
            }
            var court = _courtProvider.GetAsync("Poland", "Lazienkowska");
            team.SetTeam(teamName, description);
            await _teamRepository.AddAsync(team);
        }

        public async Task<IEnumerable<TeamDto>> BrowseAsync()
        {
            var teams = await _teamRepository.BrowseAsync();
            return _mapperRepository.Map<IEnumerable<Team>, IEnumerable<TeamDto>>(teams);
        }
    }
}
