using Ecommerce.Core.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Data.EntityConfigs
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(180);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.UnitPrice).HasColumnType("decimal(18,2)");
            builder.HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId);
            builder.HasOne(p => p.Brand).WithMany().HasForeignKey(p => p.BrandId);
            builder.ToTable("Products");
        }
    }
}
