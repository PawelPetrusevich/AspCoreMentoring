using AspCoreMentoring.DAL.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspCoreMentoring.DAL.ModelConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(prod => prod.ProductId);
            builder.Property(prod => prod.ProductName).HasMaxLength(40);
            builder.Property(prod => prod.QuantityPerUnit).HasMaxLength(20);

            builder.HasOne<Category>(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product=>product.CategoryId);

            builder.HasOne<Supplier>(product => product.Supplier)
                .WithMany(supplier => supplier.Products)
                .HasForeignKey(product=>product.SupplierId);
        }
    }
}