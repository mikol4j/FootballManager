using Core.Domain;
using Core.Repositiories;
using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Dto;
using AutoMapper;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetAsync(string email)
        {
            User user = await _userRepository.GetAsync(email);

            //return new UserDto()
            //{
            //    Id = user.Id,
            //    Email = user.Email,
            //    FullName = user.FullName,
            //    UserName = user.UserName
            //};
            return _mapper.Map<User, UserDto>(user);
            
        }

        public async Task RegisterAsync(string email, string username, string password)
        {
            User user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new Exception($"User with email '{email}' already exists.");
            }
            string salt = Guid.NewGuid().ToString("N");
            user = new User(email, username, salt, password);
            await _userRepository.AddAsync(user);
        }
    }
}
