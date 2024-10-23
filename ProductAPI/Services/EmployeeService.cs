using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Interfaces;
using ProductAPI.Models;

namespace ProductAPI.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly ProductAPIContext _context;
        public EmployeeService(ProductAPIContext context)
        {
            _context = context;
        }
        public List<Employee> GetEmployees() => _context.Employee.ToList();        

        public Employee GetEmployeeById(int id)
        {
            var employee = _context.Employee.Find(id);
            if (employee == null) return null;
            return employee;
        }
        public Employee CreateEmployee(Employee employee)
        {           
            _context.Employee.Add(employee);
            _context.SaveChanges();
            return employee;
        }
        public Employee UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = GetEmployeeById(id);
            if (existingEmployee == null) return null;
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Position = employee.Position;
            existingEmployee.Salary = employee.Salary;
            _context.SaveChanges();
            return existingEmployee;
        }
        public Employee DeleteEmployee(int id)
        {
            var existingEmployee = GetEmployeeById(id);
            if (existingEmployee == null) return null;
            _context.Employee.Remove(existingEmployee);
            _context.SaveChanges(); 
            return existingEmployee;
        }
    }
}
