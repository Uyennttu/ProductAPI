using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.DTO;
using ProductAPI.Interfaces;
using ProductAPI.Models;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeService;
        public EmployeeController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employeeList = _employeeService.GetEmployees();   
            var employeeDTOList = employeeList.Select(e => new EmployeeDTO
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Position = e.Position,
                Salary = e.Salary,
            });
            return Ok(employeeDTOList);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
           var employee = _employeeService.GetEmployeeById(id);
            if (employee == null) { return NotFound(); }
            return Ok(employee);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> CreateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = new Employee()
            {
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                Position = employeeDTO.Position,
                Salary = employeeDTO.Salary
            };
            _employeeService.CreateEmployee(employee);
            
            return CreatedAtAction("GetEmployeeById", new {id = employee.Id}, employeeDTO);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {
            var existingEmployee = _employeeService.GetEmployeeById(id);
            if (existingEmployee == null) { return NotFound(); }
            existingEmployee.FirstName = employeeDTO.FirstName;
            existingEmployee.LastName = employeeDTO.LastName;
            existingEmployee.Position = employeeDTO.Position;
            existingEmployee.Salary = employeeDTO.Salary;
           _employeeService.UpdateEmployee(id, existingEmployee);
            return Ok("Updated!");
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if(employee == null) { return NotFound(); }
            _employeeService.DeleteEmployee(id);
           
            return Ok("Deleted");
        }
    }
}
