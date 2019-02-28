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
        private readonly NorthWindContext context;
        private readonly DbSet<TModel> dbSet;

        public Repository(NorthWindContext context)
        {
            this.context = context;
            dbSet = this.context.Set<TModel>();
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

        public virtual async Task<IEnumerable<TModel>> Find(Expression<Func<TModel, bool>> filterExpression)
        {
            if (filterExpression == null)
            {
                throw new ArgumentNullException();
            }

            return await dbSet.Where(filterExpression).ToListAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}