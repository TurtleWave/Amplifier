using Amplifier.WareHouse.Core;
using Microsoft.EntityFrameworkCore;

namespace Amplifier.WareHouse.DAL;

public sealed class WareHouseContext: DbContext
{
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Cost> Costs { get; set; }
    public DbSet<Supply> Supplies { get; set; }

    public WareHouseContext()
    {
        
    }
    
    public WareHouseContext(DbContextOptions<WareHouseContext> options): base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(new Product[]
        {
            new Product() { Id = 1, Name = "Super mega game", Description = "This is super mega game", Price = 1000f },
            new Product() { Id = 2, Name = "Beta version of the newest book", Description = "book", Price = 325f },
            new Product() { Id = 3, Name = "Ball", Description = "Very round", Price = 467f },
            new Product() { Id = 4, Name = "Key", Description = "Just a key", Price = 897f },
            new Product() { Id = 5, Name = "Bank Cell", Description = "Your property in good hands!!!", Price = 229f },
            new Product() { Id = 6, Name = "Car", Description = "This is super mega game", Price = 600f },
        });

        /*modelBuilder.Entity<Supply>().HasData(new Supply[]
        {
            new Supply() { ProductId = 1, Date = DateTime.Today, Quantity = 10 }
        });*/
    }
}