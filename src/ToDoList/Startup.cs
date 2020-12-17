using System;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Services.Abstractions;
using ToDoList.Infrastructure.Persistence.Services;

namespace ToDoList
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic)
                .ToArray();

            services
                .AddMediatR(assemblies)
                .AddTransient<IDataAccess, DataAccess>(x =>
                {
                    var connStr = _config.GetConnectionString("Database");
                    return new DataAccess(connStr);
                })
                .AddControllers();
        }

        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
