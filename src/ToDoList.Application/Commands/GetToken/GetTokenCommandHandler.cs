using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Exceptions;
using ToDoList.Application.Options;
using ToDoList.Application.Services;
using ToDoList.Core;

namespace ToDoList.Application.Commands.GetToken
{
    class GetTokenCommandHandler : IRequestHandler<GetTokenCommand, string>
    {
        private readonly IDataAccess _dataAccess;
        private readonly AuthOptions _authOptions;

        public GetTokenCommandHandler(
            IDataAccess dataAccess,
            IOptions<AuthOptions> authOptions)
        {
            _dataAccess = dataAccess;
            _authOptions = authOptions.Value;
        }
        public async Task<string> Handle(
            GetTokenCommand command,
            CancellationToken cancellationToken)
        {
            User user = await GetUser(command);
            var identity = GetIdentity(user);
            var token = CreateToken(identity);

            return token;
        }

        private async Task<User> GetUser(GetTokenCommand command)
        {
            var user = await _dataAccess.GetUser(command.UserLogin, command.UserPassword);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            return user;
        }

        private string CreateToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: _authOptions.Issuer,
                    audience: _authOptions.Audience,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(_authOptions.Lifetime)),
                    signingCredentials: new SigningCredentials(_authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        private ClaimsIdentity GetIdentity(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims,
                "Token",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
    }
}
