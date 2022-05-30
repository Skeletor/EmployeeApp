using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public abstract class BaseEmployee : ICloneable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public GenderType Gender { get; set; }

        public virtual EmployeeType EmployeeType { get; }

        public abstract object Clone();

        public override string ToString() => FirstName + ' ' + LastName + ' ' + MiddleName;
    }
}
