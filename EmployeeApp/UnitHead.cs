using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class UnitHead : BaseEmployee
    {
        public string UnitName { get; set; }

        public override EmployeeType EmployeeType => EmployeeType.Руководитель_подразделения;
    }
}
