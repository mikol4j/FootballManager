﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Commands.Users
{
    public class Login : AuthenticatedCommand
    {
        public Guid TokenId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
