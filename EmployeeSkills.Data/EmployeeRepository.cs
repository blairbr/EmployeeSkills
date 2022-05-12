using Dapper;
using EmployeeSkills.Domain;
using System.Data.SqlClient;

namespace EmployeeSkills.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private const string connectionString = "Data Source = (LocalDb)\\MSSQLLocalDB; Initial Catalog = EmployeeSkills; Integrated Security = True;";
        private const string selectAllEmployeesStatement = "SELECT * FROM Employees";
        private const string addEmployeeStatement =
            @"INSERT INTO Employees (FirstName, LastName) 
              OUTPUT INSERTED.[FirstName], INSERTED.[LastName]
              VALUES @FirstName, @LastName";
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var employees = await connection.QueryAsync<Employee>(selectAllEmployeesStatement);
                return employees;
            }
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var addedEmployee = await connection.QuerySingleAsync<Employee>(addEmployeeStatement, employee);
                return addedEmployee;
            }
        }

    }
}