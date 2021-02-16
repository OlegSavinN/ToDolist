using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDoList.Application.Services;
using ToDoList.Core;
using System.Text.Json;
using System.Text.Json.Serialization;
using ToDoList.Options;
using Microsoft.Extensions.Configuration;

namespace ToDoList.Controllers
{
    //[ApiController]
    //[Route("token")]
    public class AccountController 
    {
       // private readonly IMediator _mediator;
       // private readonly IDataAccess _dataAccess;
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            //_mediator = mediator;
            //_dataAccess = dataAccess;
            _configuration = configuration;
        }

        //[HttpPost]
        //public IActionResult Token(string login, string password)
        //{
        //    var identity = GetIdentity(login, password);
        //    if (identity == null)
        //    {
        //        return BadRequest(new { errorText = "Invalid username or password." });
        //    }

        //    var _appSettings = _configuration.GetSection("AuthOptions") as AuthOptions;
        //    var now = DateTime.UtcNow;
        //    // создаем JWT-токен
        //    var jwt = new JwtSecurityToken(
        //            issuer: _appSettings.Issuer,
        //            audience: _appSettings.Audience,
        //            notBefore: now,
        //            claims: identity.Claims,
        //            expires: now.Add(TimeSpan.FromMinutes(_appSettings.Lifetime)),
        //            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        //    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        //    var response = new
        //    {
        //        access_token = encodedJwt,
        //        username = identity.Name
        //    };

        //    //return Json(response);
        //    //return JsonSerializer.Serialize<IActionResult>(response);
        //    return Ok(response);
        //}

        public IActionResult Token(User user)
        {
            var identity = GetIdentity(user);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var _appSettings = _configuration.GetSection("AuthOptions") as AuthOptions;
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: _appSettings.Issuer,
                    audience: _appSettings.Audience,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(_appSettings.Lifetime)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            //return Json(response);
            //return JsonSerializer.Serialize<IActionResult>(response);
            return Ok(response);
        }

        //private ClaimsIdentity GetIdentity(string login, string password)
        //{
        //    User user = _dataAccess.GetUser(login, password).Result;
        //    if (user != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
        //        };

        //        ClaimsIdentity claimsIdentity =
        //        new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
        //            ClaimsIdentity.DefaultRoleClaimType);
        //        return claimsIdentity;
        //    }
        //    return null;
        //}
        private ClaimsIdentity GetIdentity(User user)
        {
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
                };

                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }
    }
}
