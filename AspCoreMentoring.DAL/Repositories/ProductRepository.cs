using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AspCoreMentoring.DAL.Common.Interfaces;
using AspCoreMentoring.DAL.Common.Models;
using AspCoreMentoring.DAL.DbContext;
using Microsoft.EntityFrameworkCore;

namespace AspCoreMentoring.DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(NorthWindContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Product>> GetAll()
        {
            var result = dbSet.Include(x => x.Supplier)
                .Include(x => x.Category);
            return await result.ToListAsync();
        }
    }
}