using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task RegisterAsync(Guid userId, string email, string username, string password, string role);

        Task<UserDto> GetAsync(string email);
        Task LoginAsync(string email, string password);
    }
}
