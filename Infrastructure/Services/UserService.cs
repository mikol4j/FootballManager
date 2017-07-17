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
        private readonly IEncrypter _ecrypter;

        public UserService(IUserRepository userRepository, IMapper mapper, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _ecrypter = encrypter;
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

        public async Task LoginAsync(string email, string password)
        {
            User user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }
            var hash = _ecrypter.GetHash(password, user.Salt);
            if(user.Password == hash)
            {
                return;
            }
            throw new Exception("Invalid credentials");
        }

        public async Task RegisterAsync(string email, string username, string password, string role)
        {
            User user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new Exception($"User with email '{email}' already exists.");
            }
            string salt = _ecrypter.GetSalt(password);
            var hash = _ecrypter.GetHash(password, salt);
            user = new User(email, username, role, hash, salt);
            await _userRepository.AddAsync(user);
        }
    }
}
