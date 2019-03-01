using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspCoreMentoring.DAL.Common.Interfaces
{
    public interface IRepository<TModel>
    {
        Task<TModel> Add(TModel model);
        Task<IEnumerable<TModel>> GetAll();
        Task<IEnumerable<TModel>> GetForOnePage(int skip, int take);
        Task<IEnumerable<TModel>> Find(Expression<Func<TModel, bool>> filterExpression);
    }
}