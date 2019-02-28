using AspCoreMentoring.DAL.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspCoreMentoring.DAL.ModelConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(cat => cat.CategoryId);
            builder.Property(cat => cat.CategoryName).HasMaxLength(15);

            builder.HasMany<Product>(category => category.Products)
                .WithOne(product => product.Category);
        }
    }
}