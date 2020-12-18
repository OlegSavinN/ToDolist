using Microsoft.Extensions.Configuration;
using ToDoList.Infrastructure.Persistence.Services;

namespace ToDoList.Services.Implementations
{
    class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _configuration;

        public ConnectionStringProvider(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("Database");
        }
    }
}
