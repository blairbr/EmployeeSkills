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

        private const string addAddressStatement =
            //ADD EMPLOYEE ID back in!!
            @"INSERT INTO Address (Id, Street, Suite, City, Region, Postal, Country)
              OUTPUT INSERTED.[Id], INSERTED.[Street], INSERTED.[Suite], INSERTED.[City], INSERTED.[Region], INSERTED.[Postal], INSERTED.[Country]

              VALUES (@Id, @Street, @Suite, @City, @Region, @Postal, @Country)";
        private const string addSkillStatement =
            @"INSERT INTO Skills (Id, Experience, Summary, EmployeeId)
              OUTPUT INSERTED.[Id], INSERTED.[Experience], INSERTED.[Summary], INSERTED.[EmployeeId]
              VALUES (@Id, @Experience, @Summary, @EmployeeId)";

        //add a tech skill to a Perficient Employee
        private const string addSkillByEmployeeIdStatement =
              @"INSERT INTO Skills (Id, Experience, Summary)
              OUTPUT INSERTED.[Id], INSERTED.[Experience], INSERTED.[Summary]
              VALUES (@Id, @Experience, @Summary)
              WHERE EmployeeId = @EmployeeId"; //how does this worK? first get the employee, then insert?

        private const string addFieldBySkillIdStatement =
            @"INSERT INTO Field (Id, Name, Type)
              OUTPUT INSERTED.[Id], INSERTED.[Name], INSERTED.[Type],
              VALUES (@Id, @Name, @Type)
              WHERE SkillId = @SkillId";


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
                var addedAddress = await connection.QuerySingleAsync<Address>(addAddressStatement, employee.Address);

             //   var addedSkills = await connection.QueryAsync<List<Skill>>(addEmployeeStatement, employee.Id, employee.Skills);
                //To-do: edit this to add & return objects (Address, Skills, Fields)
                return addedEmployee; //Combine her address to her
            }
        }

    }
}