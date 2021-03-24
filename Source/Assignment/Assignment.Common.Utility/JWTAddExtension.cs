using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Assignment.Common.Utility
{
    /// <summary>
    /// Extension class for JWT
    /// </summary>
    public static class JWTAddExtension
    {
        /// <summary>
        /// Create JWT Token Validation Mehanism
        /// </summary>
        /// <param name="services"></param>
        /// <param name="builder"></param>
        public static void AddJwtAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true, // validate the server
                        ValidateAudience = true, // Validate the recipient of token is authorized to receive
                       // ValidateLifetime = true, // Check if token is not expired and the signing key of the issuer is valid 
                        ValidateIssuerSigningKey = true, // Validate signature of the token 
                       // RequireExpirationTime = true,     we are not doing this for now
                        //Issuer and audience values are same as defined in generating Token
                        ValidIssuer = configuration.GetSection("JwtConfig")["Issuer"].ToString(), // stored in appsetting file
                        ValidAudience = configuration["JwtConfig:Issuer"], // stored in appsetting file
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:secret"])), // stored in appsetting file
                       // ClockSkew = TimeSpan.Zero,
                    };
                });
        }
    }
}
