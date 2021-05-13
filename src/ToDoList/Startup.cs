using System;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Services;
using ToDoList.Extentions;
using ToDoList.Filters;
using ToDoList.Infrastructure.Persistence.Contexts;
using ToDoList.Infrastructure.Persistence.Extentions;
using ToDoList.Infrastructure.Persistence.Services;
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
            //var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            //    .Where(a => !a.IsDynamic)
            //    .ToArray();
            var assembly = AppDomain.CurrentDomain.Load("ToDoList.Application");

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(SetIdFilterAttribute)); 
            });

            services
                .AddMediatR(assembly)

                .AddTransient<IDataAccess, DataAccess>()
                .AddTransient<IConnectionStringProvider, ConnectionStringProvider>()

                .AddAuth(_config)
                .AddPersistence(_config)
                .AddMapping();

            services
                .AddControllers()
                .AddNewtonsoftJson();

            services
                 .AddSwagger();
        }

        public void Configure(
            IApplicationBuilder app,
            DatabaseContext storage)
        {
            storage.Migrate();
            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
