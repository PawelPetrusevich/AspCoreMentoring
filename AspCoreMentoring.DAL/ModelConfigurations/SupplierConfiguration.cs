using System.ComponentModel;
using AspCoreMentoring.DAL.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspCoreMentoring.DAL.ModelConfigurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(supp => supp.SupplierId);
            builder.Property(supp => supp.CompanyName).HasMaxLength(40);
            builder.Property(supp => supp.ContactName).HasMaxLength(30);
            builder.Property(supp => supp.ContactTitle).HasMaxLength(30);
            builder.Property(supp => supp.Address).HasMaxLength(60);
            builder.Property(supp => supp.City).HasMaxLength(15);
            builder.Property(supp => supp.Region).HasMaxLength(15);
            builder.Property(supp => supp.PostalCode).HasMaxLength(10);
            builder.Property(supp => supp.County).HasMaxLength(15);
            builder.Property(supp => supp.Phone).HasMaxLength(24);
            builder.Property(supp => supp.Fax).HasMaxLength(24);

            builder.HasMany<Product>(supplier => supplier.Products)
                .WithOne(product => product.Supplier);
        }
    }
}