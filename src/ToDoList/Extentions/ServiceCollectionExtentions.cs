using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ToDoList.Application.Options;
using ToDoList.Map;

namespace ToDoList.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            IConfiguration config)
        {
            var authOptionsSection = config.GetSection(nameof(AuthOptions));
            var authOptions = authOptionsSection.Get<AuthOptions>();

            services
                .Configure<AuthOptions>(x => authOptionsSection.Bind(x))
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    //options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = authOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = authOptions.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                });

            return services;
        }

        public static IServiceCollection AddMapping(
            this IServiceCollection services,
            IConfiguration config)
        {
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
