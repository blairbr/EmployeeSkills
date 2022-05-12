using EmployeeSkills.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSkills.Data
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();

        Task<Employee> AddEmployeeAsync(Employee employee);
    }
}
