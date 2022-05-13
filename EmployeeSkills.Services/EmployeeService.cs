using EmployeeSkills.Data;
using EmployeeSkills.Domain;

namespace EmployeeSkills.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var employees = await employeeRepository.GetEmployeesAsync();
            return employees;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            var addedEmployee = await employeeRepository.AddEmployeeAsync(employee);
            return addedEmployee;
        }
    }
}