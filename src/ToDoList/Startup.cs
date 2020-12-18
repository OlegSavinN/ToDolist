using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Services;
using ToDoList.Infrastructure.Persistence.Services;
using ToDoList.Infrastructure.Persistence.Services.Implementations;
using ToDoList.Services.Implementations;

namespace ToDoList
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(
            IConfiguration configuration)
        {
            _config = configuration;
        }

        public void ConfigureServices(
            IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic)
                .ToArray();

            services
                .AddMediatR(assemblies)
                
                .AddTransient<IDataAccess, DataAccess>()
                .AddTransient<IConnectionStringProvider, ConnectionStringProvider>()
                .AddControllers();
        }

        public void Configure(
            IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
