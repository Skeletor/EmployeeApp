using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class Worker : BaseEmployee
    {
        public string HeadLFM { get; set; }

        public override EmployeeType EmployeeType => EmployeeType.Рабочий;
    }
}
