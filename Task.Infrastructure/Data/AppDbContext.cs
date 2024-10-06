using Microsoft.EntityFrameworkCore;
using Task.Domain.Entities;

namespace Task.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Store> Stores { get; set; }
    public DbSet<StoreSpace> Spaces { get; set; }
    public DbSet<Product> Products { get; set; }



    public AppDbContext() { }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Store>(entity =>
        {
            entity.ToTable("Stores");

            entity.HasData(
                new List<Store>() 
                {
                    new Store() { Id = 1, Name = "Main Store", IsMain = true, IsInvoiceDirect = true, Address = "Al Gammal St - Cairo - Egypt" },
                    new Store() { Id = 2, Name = "Electric Store", IsMain = false, IsInvoiceDirect = true, Address = "Ain Shams St - Cairo - Egypt" },
                    new Store() { Id = 3, Name = "Food Store", IsMain = false, IsInvoiceDirect = false, Address = "Port Said St - Cairo - Egypt" },
                    new Store() { Id = 4, Name = "Machines Store", IsMain = false, IsInvoiceDirect = false, Address = "Port Said St - Cairo - Egypt" },
                });
            entity.HasMany(x => x.Spaces)
            .WithOne(x => x.Store)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<StoreSpace>(entity =>
        {
            entity.ToTable("StoreSpaces");

            entity.HasOne(x => x.Store)
            .WithMany(x => x.Spaces)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.SetNull);

            entity.HasData(
                new List<StoreSpace>()
                {
                    new StoreSpace() { Id = 1, Name = "Default", StoreId = 1},
                    new StoreSpace() { Id = 2, Name = "Default", StoreId = 2},
                    new StoreSpace() { Id = 3, Name = "Default", StoreId = 3},
                    new StoreSpace() { Id = 4, Name = "Default", StoreId = 4},
                });
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Products");

            entity.HasOne(x => x.Space)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.StoreSpaceId)
            .OnDelete(DeleteBehavior.SetNull);


            entity.HasData(
                new List<Product>()
                {
                    new Product() { Id = 1, Name = "Default Product Name 1", StoreSpaceId = 1},
                    new Product() { Id = 2, Name = "Default Product Name 2", StoreSpaceId = 2},
                    new Product() { Id = 3, Name = "Default Product Name 3", StoreSpaceId = 3},
                    new Product() { Id = 4, Name = "Default Product Name 4", StoreSpaceId = 4},
                });
        });
    }
}