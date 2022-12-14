using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Data.Config
{
  public class ProductConfiguration : IEntityTypeConfiguration<Product>
  {
    public void Configure(EntityTypeBuilder<Product> builder)
    {
      builder.Property(p => p.Name).HasMaxLength(100);
      builder.Property(p => p.Description).HasMaxLength(180);
      builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
    }
  }
}