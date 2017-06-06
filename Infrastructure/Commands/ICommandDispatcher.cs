using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public interface ICommandDispatcher
    {
        Task DsipatchAsync<T>(T command) where T : ICommand;
    }
}
