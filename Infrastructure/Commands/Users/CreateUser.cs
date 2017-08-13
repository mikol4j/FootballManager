using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Commands.Users
{
    public class CreateUser : AuthenticatedCommand
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }
    }
}
