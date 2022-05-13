namespace EmployeeSkills.Domain
{
    public class Employee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string ContactEmail { get; set; }
        public string CompanyEmail { get; set; }
        public string BirthDate { get; set; }
        public string HiredDate { get; set; }
        public string Role { get; set; } // default = Technical Consultant
        public string BusinessUnit { get; set; }
        public List<Skill> Skills { get; set; } 
        public string AssignedTo { get; set; } //look at swagger again for this
    }
}