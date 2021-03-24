using Assignment.BusinessLogic.Contracts;
using Assignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Assignment.EmployeeMicroService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeLogic _employeeLogic;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeLogic employeeLogic)
        {
            _logger = logger;
            _employeeLogic = employeeLogic;
        }

        [HttpPost("register"), AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] EmployeeRegisterModel user)
        {
            _logger.LogInformation("", user);
           
            await _employeeLogic.RegisterEmployee(user);

            return Ok();
        }

        [HttpGet("get"), Authorize]
        public IActionResult Get()
        {
            var empId = GetEmployeeId();

            var emp= _employeeLogic.GetEmployee(empId);

            return Ok(emp);
        }
        protected virtual int GetEmployeeId()
        {
            var claims = (ClaimsIdentity)User.Identity;
            var id = claims.Claims.SingleOrDefault(c => c.Type == "Id");

            if (id == null)
                return 0;

            var empId = int.Parse(id.Value);
            return empId;
        }

    }
}
