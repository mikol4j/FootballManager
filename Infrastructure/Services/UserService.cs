using Core.Domain;
using Core.Repositiories;
using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Dto;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto Get(string email)
        {
            User user = _userRepository.Get(email);

            return new UserDto()
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                UserName = user.UserName
            };
            
        }

        public void Register(string email, string username, string password)
        {
            User user = _userRepository.Get(email);
            if(user != null)
            {
                throw new Exception($"User with email '{email}' already exists.");
            }
            string salt = Guid.NewGuid().ToString("N");
            user = new User(email, username, salt, password);
            _userRepository.Add(user);
        }
    }
}
