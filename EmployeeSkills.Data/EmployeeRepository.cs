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
            @"INSERT INTO Employees (Id, FirstName, LastName, ContactEmail, CompanyEmail, BirthDate, HiredDate, Role, BusinessUnit) 
              OUTPUT INSERTED.[Id], INSERTED.[FirstName], INSERTED.[LastName], INSERTED.[ContactEmail], INSERTED.[CompanyEmail], INSERTED.[BirthDate], INSERTED.[HiredDate], INSERTED.[Role], INSERTED.[BusinessUnit]
              VALUES (@Id, @FirstName, @LastName, @ContactEmail, @CompanyEmail, @BirthDate, @HiredDate, @Role, @BusinessUnit) ";
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
                //To-do: edit this to add & return objects (Address, Skills, Fields)
                return addedEmployee;
            }
        }

    }
}