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
using Xunit;

namespace TestsEndToEnd
{
    //https://docs.microsoft.com/en-us/aspnet/core/testing/integration-testing
    public class UserControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UserControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

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
            var response = await _client.GetAsync($"users/{email}");

            // Assert
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);

        }

        [Fact]
        public async Task GivenUniqueEmailUserShouldBeCreated()
        {
            // Arrange
            var request = new CreateUser
            {
                Email = "test@email.com",
                Username = "test",
                Password = "secret"
            };
            var payload = GetPayload(request);
           
            //Act
            var response = await _client.PostAsync("users",payload);


            // Assert
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"users/{request.Email}");

            var user = await GetUserAsync(request.Email);
            user.Email.ShouldBeEquivalentTo(request.Email);

        }

        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await _client.GetAsync($"users/{email}");

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
