using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.ProductName).IsRequired();
        builder.Property(p => p.Price).IsRequired();
        
        builder.HasData(
            new Product() { Id = 1, ProductName = "Computer", categoryId = 1, Price = 12000 },
            new Product() { Id = 2, ProductName = "Keyboard", categoryId = 1, Price = 1000 },
            new Product() { Id = 3, ProductName = "Mouse", categoryId = 1, Price = 2000 },
            new Product() { Id = 4, ProductName = "Monitor", categoryId = 1, Price = 4000 }
        );
    }
}