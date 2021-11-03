using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Models;
using Portfolio.Repositories;
using Portfolio.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Portfolio.Services
{
    public interface IIdentityService
    {
        string GenerateAccessToken(int userId, string userLogin, string roleName);
    }
    public class IdentityService : IIdentityService
    {
        private readonly IConfiguration Configuration;
        public IdentityService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GenerateAccessToken(int userId, string userLogin, string roleName)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("SecretKey").Value));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", userId.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, userLogin),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, roleName),
            };
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "issuer",
                audience: "audience",
                claims: claims,
                expires: DateTime.Now.AddDays(90),
                signingCredentials: signingCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
