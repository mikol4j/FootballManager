using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; protected set; }

        public string Password { get; protected set; }

        public string Salt { get; protected set; }

        public string UserName { get; protected set; }

        public string FullName { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        protected User()
        {
            //protects from creating parameterless instance
        }

        public User(string email, string username, string password, string salt )
        {
            Id = new Guid();
            Email = email;
            UserName = username;
            Password = password;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
        }
    }


}
