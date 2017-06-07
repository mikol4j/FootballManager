using FluentAssertions;
using Infrastructure.Commands.Users;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestsEndToEnd.Controllers
{
    public class AccountControllerTests : ControllerTestsBase
    {

        [Fact]
        public async Task GivenValidCurrentAndNewPasswordItShouldBeChanged()
        {
            // Arrange
            var command = new ChangeUserPassword
            {
                CurrentPassword = "secret",
                NewPassword = "secret2"
            };
            var payload = GetPayload(command);

            //Act
            var response = await Client.PutAsync("account/password", payload);


            // Assert
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);


        }
    }
}
