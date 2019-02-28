using AspCoreMentoring.DAL.Common.Interfaces;
using AspCoreMentoring.DAL.Common.Models;
using AspCoreMentoring.DAL.DbContext;

namespace AspCoreMentoring.DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(NorthWindContext context) : base(context)
        {
        }
    }
}