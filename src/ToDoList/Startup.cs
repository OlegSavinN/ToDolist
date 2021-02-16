using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ToDoList.Application.Services;
using ToDoList.Infrastructure.Persistence.Services;
using ToDoList.Infrastructure.Persistence.Services.Implementations;
using ToDoList.Options;
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

                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    //options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //ValidateIssuer = true,
                        //ValidIssuer = AuthOptions.Issuer,
                        //ValidateAudience = true,
                        //ValidAudience = AuthOptions.Audience,
                        //ValidateLifetime = true,
                        //IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        //ValidateIssuerSigningKey = true,
                    };
                });

            services
                .AddControllers()
                .AddNewtonsoftJson();
        }

        public void Configure(
            IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
