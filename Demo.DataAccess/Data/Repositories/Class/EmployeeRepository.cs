using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Data.Repositories.Interfaces;
using Demo.DataAccess.Entities.EmployeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Repositories.Implementation
{
    public class EmployeeRepository(ApplicationDbContext dbContext) : GenericRepository<Employee>(dbContext), IEmployeeRepository
    {
        public IEnumerable<Employee> GetAllWithDepartment(bool withTracking = false)
        {
            var query = dbContext.Employees.Include(e => e.Department);

            return withTracking ? query : query.AsNoTracking();
        }

    }
}
