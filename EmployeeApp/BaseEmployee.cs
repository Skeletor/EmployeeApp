using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public abstract class BaseEmployee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public GenderType Gender { get; set; }

        public abstract EmployeeType EmployeeType { get; }

        public override string ToString() => FirstName + ' ' + LastName + ' ' + MiddleName;
    }
}
