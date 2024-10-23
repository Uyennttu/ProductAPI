using ProductAPI.Models;

namespace ProductAPI.Interfaces
{
    public interface IEmployee
    {
        public List<Employee> GetEmployees();
        public Employee GetEmployeeById(int id);
        public Employee CreateEmployee(Employee employee);
        public Employee UpdateEmployee(int id, Employee employee);
        public Employee DeleteEmployee(int id);
    }
}
