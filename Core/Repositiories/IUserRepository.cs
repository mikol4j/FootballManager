using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositiories
{
    //COMMAND-QUERY SEPARATION PATTERN (CQS)
    public interface IUserRepository
    {
        User Get(Guid id);
        User Get(string email);
        void Add(User user);
        void Update(User user);
        void Remove(Guid id);

    }
}
