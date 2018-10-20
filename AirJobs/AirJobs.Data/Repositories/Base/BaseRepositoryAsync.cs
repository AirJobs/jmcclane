using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirJobs.Data.Context;
using AirJobs.Domain.Entities.Base;
using AirJobs.Domain.Interfaces.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirJobs.Data.Repositories.Base
{
    public abstract class BaseRepositoryAsync<TEntity> : IBaseRepositoryAsync<TEntity> where TEntity : BaseEntity
    {
        protected AirJobsContext DbContext;
        protected DbSet<TEntity> DbSet;

        protected BaseRepositoryAsync(AirJobsContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> List()
        {
            return await DbSet.ToListAsync();
        }

        public virtual Task<List<TEntity>> List(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToListAsync();
        }

        public virtual Task<TEntity> Get(Guid id)
        {
            return DbSet.FindAsync(id);
        }

        public virtual Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            var taskResuçt = await DbSet.AddAsync(entity);
            return taskResuçt.Entity;
        }

        public virtual async Task Add(ICollection<TEntity> entities)
        {
            foreach (var entity in entities) entity.Id = Guid.NewGuid();

            await DbSet.AddRangeAsync(entities);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return DbSet.Update(entity).Entity;
        }

        public virtual void Update(ICollection<TEntity> entites)
        {
            DbSet.UpdateRange(entites);
        }

        public virtual TEntity Remove(TEntity entity)
        {
            return DbSet.Remove(entity).Entity;
        }

        public virtual async Task<TEntity> Remove(Guid id)
        {
            var entity = await Get(id);
            if (entity == null) return null;
            return Remove(entity);
        }

        public virtual void Remove(ICollection<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public virtual async Task Remove(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await List(predicate);
            if (entities.Any()) Remove(entities);
        }

        protected List<TEntity> Paginate(IEnumerable<TEntity> query, int page, int size)
        {
            return query
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();
        }
    }
}