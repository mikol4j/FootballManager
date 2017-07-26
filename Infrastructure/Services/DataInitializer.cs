using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public DataInitializer(IUserService userService, ILogger<DataInitializer> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        public async Task SeedAsync()
        {

            _logger.LogTrace("Initializaing data...");
            var tasks = new List<Task>();
            for (int i = 1; i < 10; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"user{i}";

                tasks.Add(_userService.RegisterAsync(userId, $"{username}@test.com",username,"secret", "user"));
            }
            await Task.WhenAll(tasks);

            for (int i = 1; i < 3; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"admin{i}";

                tasks.Add(_userService.RegisterAsync(userId, $"{username}@test.com", username, "secret", "user"));
            }
            await Task.WhenAll(tasks);
            _logger.LogTrace("Data was initialized.");
        }
    }
}
