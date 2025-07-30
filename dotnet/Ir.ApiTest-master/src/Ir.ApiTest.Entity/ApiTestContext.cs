﻿using Ir.ApiTest.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ir.ApiTest.Entity;

public class ApiTestContext : DbContext
{
  #region Public Constructors

  public ApiTestContext(DbContextOptions<ApiTestContext> options) : base(options)
  {
  }

  #endregion Public Constructors

  #region Public Properties

  public DbSet<Product> Products { get; set; }

  #endregion Public Properties

  #region Protected Members

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    ConfigureProduct(modelBuilder.Entity<Product>());

    base.OnModelCreating(modelBuilder);
  }

  private void ConfigureProduct(EntityTypeBuilder<Product> product)
  {
    product.ToTable(nameof(Product));
    product.HasKey(x => x.Id);
    product
      .Property(x => x.Created)
      .HasConversion(x => x.UtcDateTime, x => DateTime.SpecifyKind(x, DateTimeKind.Utc));
    product
      .Property(x => x.LastUpdated)
      .HasConversion(x => x.UtcDateTime, x => DateTime.SpecifyKind(x, DateTimeKind.Utc));
  }

  #endregion Protected Members
}
