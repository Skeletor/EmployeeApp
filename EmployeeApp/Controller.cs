using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    public class Controller : BaseEmployee
    {
        public string EquipmentName { get; set; }

        public override EmployeeType EmployeeType => EmployeeType.Контролёр;

        public override object Clone() => new Controller
        {
            FirstName = FirstName,
            LastName = LastName,
            MiddleName = MiddleName,
            DateOfBirth = DateOfBirth,
            Gender = Gender,
            EquipmentName = EquipmentName
        };
    }
}
