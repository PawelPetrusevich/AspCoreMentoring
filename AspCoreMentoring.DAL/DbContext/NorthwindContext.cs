using AspCoreMentoring.DAL.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCoreMentoring.DAL.DbContext
{
    public class NorthWindContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public NorthWindContext(DbContextOptions<NorthWindContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NorthWindContext).Assembly);
        }
    }
}