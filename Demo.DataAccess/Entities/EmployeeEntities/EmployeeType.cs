using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Entities.EmployeEntities
{
    public enum EmployeeType
    {
        FullTime = 1,
        PartTime = 2,
        ProjectBased = 4,
        Intern = 8,
        Contract = 16
    }
}
