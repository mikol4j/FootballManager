using FluentAssertions;
using Infrastructure.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Net.Http;
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
            var response = await _client.GetAsync($"users/{email}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(responseString);

            // Assert
            Assert.Equal(user.Email, email);
            //user.Email.ShouldAllBeEquivalentTo(email);
        }
    }
}
