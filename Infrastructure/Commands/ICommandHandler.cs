using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HadnleAsync(T command);
    }
}
