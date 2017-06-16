using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task RegisterAsync(string email, string username, string password);

        Task<UserDto> GetAsync(string email); 
    }
}
