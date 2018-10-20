using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirJobs.Domain.Interfaces.Data.Repositories
{
    public interface IBaseRepositoryAsync<TEntity>
    {
        Task<List<TEntity>> List();
        Task<List<TEntity>> List(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Get(Guid id);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task Add(ICollection<TEntity> entities);
        Task<TEntity> Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Update(ICollection<TEntity> entites);
        Task<TEntity> Remove(Guid id);
        TEntity Remove(TEntity entity);
        void Remove(ICollection<TEntity> entities);
        Task Remove(Expression<Func<TEntity, bool>> predicate);
    }
}