using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class CommandDispatcher
    {
        private readonly IComponentContext _context;
        public CommandDispatcher(IComponentContext cotenxt)
        {
            _context = _context;
        }

        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command), $"Commant '{typeof(T).Name}' can not be null.");
                var handler = _context.Resolve<ICommandHandler<T>>();

                await handler.HadnleAsync(command);
            }
        }
    }
}
