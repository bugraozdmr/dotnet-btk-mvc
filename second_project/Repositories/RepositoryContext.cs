using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasData(
            new Product() {Id = 1,ProductName = "Computer",Price = 12000},
            new Product() {Id = 2,ProductName = "Keyboard",Price = 1000},
            new Product() {Id = 3,ProductName = "Mouse",Price = 2000},
            new Product() {Id = 4,ProductName = "Monitor",Price = 4000}
            );
    }

    public DbSet<Product> Products { get; set; }
}