using FluentAssertions;
using Infrastructure.Commands.Users;
using Infrastructure.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using testdotnet2;
using TestsEndToEnd.Controllers;
using Xunit;

namespace TestsEndToEnd
{
    //https://docs.microsoft.com/en-us/aspnet/core/testing/integration-testing
    public class UserControllerTests : ControllerTestsBase
    {


        [Fact]
        public async Task GivenValidEmailUserShouldExit()
        {
            // Arrange
            string email = "user1@gmail.com";
            //Act
            var user = await GetUserAsync(email);

            // Assert
            Assert.Equal(user.Email, email);
            user.Email.ShouldBeEquivalentTo(email);
        }

        [Fact]
        public async Task GivenInvalidEmailUserShouldNotExit()
        {
            // Arrange
            string email = "user19@gmail.com";
            //Act
            var response = await Client.GetAsync($"users/{email}");

            // Assert
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);

        }

        [Fact]
        public async Task GivenUniqueEmailUserShouldBeCreated()
        {
            // Arrange
            var command = new CreateUser
            {
                Email = "test@email.com",
                Username = "test",
                Password = "secret"
            };
            var payload = GetPayload(command);
           
            //Act
            var response = await Client.PostAsync("users",payload);


            // Assert
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"users/{command.Email}");

            var user = await GetUserAsync(command.Email);
            user.Email.ShouldBeEquivalentTo(command.Email);

        }

        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"users/{email}");

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }


    }
}
