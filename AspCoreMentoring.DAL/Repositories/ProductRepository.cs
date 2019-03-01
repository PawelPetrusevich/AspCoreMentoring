using System.Collections.Generic;
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
            await context.Categories.LoadAsync();
            return await base.GetAll();
        }
    }
}