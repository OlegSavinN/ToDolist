using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
