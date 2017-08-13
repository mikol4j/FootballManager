using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Commands
{
    public class AuthenticatedCommand : IAuthenticatedCommand
    {
        public Guid UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
