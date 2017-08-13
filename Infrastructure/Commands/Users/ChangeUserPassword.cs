using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Commands.Users
{
    public class ChangeUserPassword : AuthenticatedCommand
    {
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
