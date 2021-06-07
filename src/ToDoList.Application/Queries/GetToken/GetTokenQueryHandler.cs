using MediatR;
using Microsoft.EntityFrameworkCore;
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
using ToDoList.Core.Entities;
using ToDoList.Infrastructure.Persistence.Contexts;

namespace ToDoList.Application.Queries.GetToken
{
    public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, string>
    {
        private readonly DatabaseContext _storage;
        private readonly AuthOptions _authOptions;

        public GetTokenQueryHandler(
            DatabaseContext storage,
            IOptions<AuthOptions> authOptions)
        {
            _storage = storage;
            _authOptions = authOptions.Value;
        }
        public async Task<string> Handle(
            GetTokenQuery query,
            CancellationToken cancellationToken)
        {
            User user = await GetUser(query, cancellationToken);
            var identity = GetIdentity(user);
            var token = CreateToken(identity);

            return token;
        }

        private async Task<User> GetUser(
            GetTokenQuery query,
            CancellationToken cancellationToken)
        {
            User user = await _storage.Users.FirstOrDefaultAsync(
                x => x.Login == query.Login && x.Password == query.Password,
                cancellationToken);

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
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, Convert.ToString(user.Role)),
                new Claim("UserId", Convert.ToString(user.Id))
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
