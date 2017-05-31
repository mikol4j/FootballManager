using Core.Repositiories;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Domain;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private static ISet<User> _users = new HashSet<User>
        {
            new User("user1@gmail.com", "user1", "secret", "salt"),
            new User("user2@gmail.com", "user2", "secret", "salt"),
            new User("user3@gmail.com", "user3", "secret", "salt"),

        };


        public void Add(User user)
        {
            if(!_users.Contains(user))
            {
                _users.Add(user);
            }
            else
            {
                throw new Exception("User already exits");
            }

        }

        public User Get(Guid id)
            =>_users.SingleOrDefault(x => x.Id == id);


        public User Get(string email)
            => _users.Single(x => x.Email == email);

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
