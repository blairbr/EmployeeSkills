using EmployeeSkills.Domain;
using EmployeeSkills.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSkills.Controllers
{
    [Route("employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }


        [HttpGet]
        [EnableCors("_myAllowSpecificOrigins")]
        public async Task<IActionResult> GetEmployeesAsync()
        {
            var returnedEmployees = await employeeService.GetEmployeesAsync();
            return Ok(returnedEmployees);
        }

        [HttpPost]
        [EnableCors("_myAllowSpecificOrigins")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody]Employee employee)
        {
            var addedEmployee = await employeeService.AddEmployeeAsync(employee);

            return Ok(addedEmployee);

            //Also need check data and to return '422 - Invalid Perficient employee data sent to server.' if the request is invalid
        }
    }
}
