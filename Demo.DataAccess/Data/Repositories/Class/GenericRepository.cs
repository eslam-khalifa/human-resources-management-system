using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Data.Repositories.Interfaces;
using Demo.DataAccess.Entities.DepartmentModel;
using Demo.DataAccess.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Repositories.Implementation
{
    public class GenericRepository<TEntity>(ApplicationDbContext dbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _dbcontext = dbContext;

        public IEnumerable<TEntity> GetAll(bool withTracking = false)
        {
            if (!withTracking)
            {
                return _dbcontext.Set<TEntity>().AsNoTracking().Where(e => e.IsDeleted == false);
            }
            return _dbcontext.Set<TEntity>().Where(e => e.IsDeleted == false);
        }

        public async Task<TEntity?> GetByIdAsync(int? id, bool withTracking = false)
        {
            if (!withTracking)
            {
                return await _dbcontext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            }
            return await _dbcontext.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Remove(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbcontext.Set<TEntity>().AddAsync(entity);
        }

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector, bool withTracking = false)
        {
            return await _dbcontext.Set<TEntity>().Where(e => e.IsDeleted == false)
                                            .Select(selector)
                                            .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbcontext.Set<TEntity>().Where(predicate).ToListAsync();
        }
    }
}
