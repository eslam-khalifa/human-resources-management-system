using Demo.DataAccess.Entities.EmployeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Repositories.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        new IEnumerable<Employee> GetAll(bool withTracking = false);
    }
}
