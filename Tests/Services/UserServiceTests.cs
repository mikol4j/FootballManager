using AutoMapper;
using Core.Domain;
using Core.Repositiories;
using FluentAssertions;
using Infrastructure.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task RegisterAsyncShouldInvoke()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
           // var userService = new UserService(userRepositoryMock.Object,mapperMock.Object);

           // await userService.RegisterAsync("user@email.com", "", "user", "password");
            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
