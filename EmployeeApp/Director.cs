using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class Director : BaseEmployee
    {
        public string CabinetNumber { get; set; }

        public override EmployeeType EmployeeType => EmployeeType.Директор;
    }
}
