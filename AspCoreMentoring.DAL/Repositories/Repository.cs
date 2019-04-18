using AspCoreMentoring.DAL.Common.Interfaces;
using AspCoreMentoring.DAL.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspCoreMentoring.DAL.Repositories
{
    public class Repository<TModel> : IRepository<TModel>, IDisposable where TModel : class
    {
        private bool disposedFlag = false;
        protected readonly NorthWindContext context;
        protected readonly DbSet<TModel> dbSet;

        public Repository(NorthWindContext context)
        {
            this.context = context;
            dbSet = this.context.Set<TModel>();
        }

        ~Repository()
        {
            Dispose(false);
        }

        public virtual async Task<TModel> Add(TModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            await dbSet.AddAsync(model);
            await context.SaveChangesAsync();

            return model;
        }

        public virtual async Task<IEnumerable<TModel>> GetAll()
        {
            var result = await dbSet.ToListAsync();
            return result;
        }

        public virtual async Task<IEnumerable<TModel>> GetAll(params Expression<Func<TModel, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            var result = await query.ToListAsync();
            return result;
        }

        public virtual async Task<IEnumerable<TModel>> GetForOnePage(int skip, int take)
        {
            if (skip < 0 || take < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return await dbSet.Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<IEnumerable<TModel>> Find(Expression<Func<TModel, bool>> filterExpression)
        {
            if (filterExpression == null)
            {
                throw new ArgumentNullException();
            }

            return await dbSet.Where(filterExpression).ToListAsync();
        }

        public virtual async Task<IEnumerable<TModel>> Find(Expression<Func<TModel, bool>> filterExpression, params Expression<Func<TModel, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            var result = await query.Where(filterExpression).ToListAsync();
            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                return;
            }

            disposedFlag = true;
        }

        public void Dispose()
        {
            Dispose(disposedFlag);
            GC.SuppressFinalize(this);
        }

        private IQueryable<TModel> GetAllIncluding(params Expression<Func<TModel, object>>[] includeProperties)
        {
            IQueryable<TModel> queryable = dbSet.AsNoTracking();

            return includeProperties.Aggregate(
                queryable,
                (current, includeProperty) => current.Include(includeProperty));
        }
    }
}