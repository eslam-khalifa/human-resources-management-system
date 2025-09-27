using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Data.Repositories.Implementation;
using Demo.DataAccess.Data.Repositories.Interfaces;
using Demo.DataAccess.Data.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.UnitOfWork.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Lazy<IDepartmentRepository> _departmentRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(dbContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(dbContext));
            _dbContext = dbContext;
        }

        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;

        public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
    }
}
