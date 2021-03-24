using Assignment.AuthMicroService.Services;
using Assignment.BusinessLogic.Contracts;
using Assignment.Common.Helper;
using Assignment.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.AuthMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController, AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenBuilder _tokenBuilder;
        private readonly IEmployeeLogic _employeeLogic;


        public AuthenticationController(
            IEmployeeLogic employeeLogic,
            ITokenBuilder tokenBuilder)
        {
            _tokenBuilder = tokenBuilder;
            _employeeLogic = employeeLogic;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] EmployeeLoginModel user)
        {
            var userInfo = await _employeeLogic.FindByUsername(user.Email);

            if (userInfo == null)
            {
                return NotFound("User not found.");
            }

            var password = user.Password + userInfo.PasswordSalt;
            var passwordHash = PasswordHelper.Sha256_UnicodeHash(password);

            if (passwordHash != userInfo.PasswordHash)
                return BadRequest("Invalid password.");

            var token = _tokenBuilder.BuildToken(userInfo);

            return Ok(token);
        }

        [HttpGet("verify")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> VerifyToken()
        {
            var username = User
                .Claims
                .SingleOrDefault();

            if (username == null)
            {
                return Unauthorized();
            }

            var user = await _employeeLogic
                .FindByUsername(username.Value);

            if (user == null)
            {
                return Unauthorized();
            }

            return NoContent();
        }
    }
}
