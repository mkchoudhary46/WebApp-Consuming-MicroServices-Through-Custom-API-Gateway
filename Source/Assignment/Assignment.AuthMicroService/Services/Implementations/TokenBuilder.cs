using Assignment.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Assignment.AuthMicroService.Services.Implementations
{
    public class TokenBuilder : ITokenBuilder
    {
        private readonly string _secret;
        private readonly string _expDate;
        private readonly string _issuer;
        private readonly IConfiguration _configuration;
        public TokenBuilder(IConfiguration config)
        {
            _configuration = config;

            _secret = config.GetSection("JwtConfig").GetSection("secret").Value;
            _secret = config.GetSection("JwtConfig").GetSection("secret").Value;
            _issuer = config.GetSection("JwtConfig").GetSection("Issuer").Value;
        }
        public string BuildToken(UserViewModel userInfo)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userInfo.Email),
                    new Claim("Id", userInfo.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.GivenName, userInfo.Name)
                }),
                //Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer= _issuer,
                Audience= _issuer,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
