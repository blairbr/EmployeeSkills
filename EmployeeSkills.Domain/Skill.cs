using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSkills.Domain
{
    public class Skill
    {
        public string Id { get; set; }
        public Field field { get; set; }
        public int Experience { get; set; }
        public string summary { get; set; }

  //      public List<string> EmployeeId { get; set; }

    }
}
