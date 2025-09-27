using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Data.Repositories.Interfaces;
using Demo.DataAccess.Entities.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Repositories.Implementation
{
    public class DepartmentRepository(ApplicationDbContext dbContext) : GenericRepository<Department>(dbContext), IDepartmentRepository
    {
    }
}
