using Demo.DataAccess.Entities.DepartmentModel;
using Demo.DataAccess.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Repositories.Interfaces
{
    public interface IGenericRepository <TEntity> where TEntity : BaseEntity
    {
        Task AddAsync(TEntity entity);
        IEnumerable<TEntity> GetAll(bool withTracking = false);
        Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector, bool withTracking = false);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> GetByIdAsync(int? id, bool withTracking = false);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
