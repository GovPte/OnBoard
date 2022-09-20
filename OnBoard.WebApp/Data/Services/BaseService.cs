using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OnBoard.WebApp.Data.Services
{
    /// <summary>
    /// Base Repository to provide EF operations for entities that have a primary key of ID
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class //, Entity
    {
        internal DbContext _context;
        internal DbSet<TEntity> _dbSet;

        // TODO Set to CMSDataContext (not DbContext) as three DbContexts are currently available
        public BaseService(DataModelDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> All()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> AllInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties).ToList();
        }

        public IEnumerable<TEntity> FindByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IEnumerable<TEntity> results = query.Where(predicate).ToList();
            return results;
        }

        private IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = _dbSet.AsNoTracking();

            return includeProperties.Aggregate
              (queryable, (current, includeProperty) => current.Include(includeProperty));
        }
        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {

            IEnumerable<TEntity> results = _dbSet.AsNoTracking().Where(predicate).ToList();
            return results;
        }

        public IQueryable<TEntity> FindByEnumerable(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> results = _dbSet.AsNoTracking().Where(predicate);
            return results;
        }

        public TEntity FindByKey(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            //if (_context.ChangeTracker.Entries<TEntity>().Any(e => e.Entity.ID == entity.ID))
            //{
            //    _dbSet.Attach(entity);
            //}

            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = FindByKey(id);
            _dbSet.Remove(entity);
        }
    }
}