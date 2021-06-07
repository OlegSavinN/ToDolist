using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Infrastructure.Persistence.Contexts;
using ToDoList.Infrastructure.Persistence.Options;

namespace ToDoList.Infrastructure.Persistence.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration config)
        {
            var databaseContextOptions = config.GetSection(nameof(DatabaseContextOptions));

            services
                .Configure<DatabaseContextOptions>(databaseContextOptions.Bind)
                .AddDbContext<DatabaseContext>();

            return services;
        }
    }
}
