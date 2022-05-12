using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSkills.Domain
{
    public class Field
    {
        public string Id { get; set; }
        public Field field { get; set;  }
        public int Experience { get; set; }
        public string Summary { get; set; }
    }
}
