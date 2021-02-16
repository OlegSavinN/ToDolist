﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ToDoList.Options
{
    public class AuthOptions
    {      
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int Lifetime { get; set; }

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes("asd"));
            ////return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}