using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyBank.Shared;
using StarBank.Server.Repository;
//using StarBank.Server.Repository;

namespace StarBank.Server.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _usermanager;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _usermanager = employeeRepository;
        }
        //api/Employees/AddEmployee
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> Add(Employee employee)
        {
           
          var result= await _usermanager.AddEmployee(employee);
            return Ok(result);
        }


        [HttpPost]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> Update(Employee employee)
        {

            var result = await _usermanager.UpdateEmployee(employee);
            return Ok(result);
        }
        //api/Employees/GetAllEmployees
        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {

            var result = await _usermanager.GetEmployee();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllEmployeeByEmail/{email}")]
        public async Task<IActionResult> GetAllEmployeeByEmail(string email)
        {

            var result = await _usermanager.GetEmployeeByEmail(email);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteEmployee/{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {

            await _usermanager.DeleteEmployee(employeeId);
            return Ok();
        }

        [HttpGet]
        [Route("search/{name}")]
        public async Task<IActionResult> Search(string name, Gender? gender)
        {

            var userList = await _usermanager.Search(name,gender);
            return Ok(userList);
        }





    }
}
