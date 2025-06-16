using Coffee_Shop_POS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Coffee_Shop_POS.Data;

public class ProductsContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite("Data Source = products.db")
            .EnableSensitiveDataLogging()
            .UseLoggerFactory(GetLoggerFactory());
    }

    private ILoggerFactory? GetLoggerFactory()
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
            builder.AddFilter(
                (category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information
            );
        });

        return loggerFactory;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.OrderId, op.ProductId });

        modelBuilder
            .Entity<OrderProduct>()
            .HasOne(op => op.Order)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(op => op.OrderId);

        modelBuilder
            .Entity<OrderProduct>()
            .HasOne(op => op.Product)
            .WithMany(p => p.OrderProducts)
            .HasForeignKey(op => op.ProductId);

        modelBuilder
            .Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder
            .Entity<Category>()
            .HasData(
                new List<Category>
                {
                    new Category { CategoryId = 1, Name = "Beverages" },
                    new Category { CategoryId = 2, Name = "Pastries" },
                    new Category { CategoryId = 3, Name = "Sandwiches" },
                    new Category { CategoryId = 4, Name = "Snacks" },
                }
            );

        modelBuilder
            .Entity<Product>()
            .HasData(
                new List<Product>
                {
                    new Product
                    {
                        ProductId = 1,
                        Name = "Coffee",
                        Price = 2.49m,
                        CategoryId = 1,
                    },
                    new Product
                    {
                        ProductId = 2,
                        Name = "Latte",
                        Price = 2.99m,
                        CategoryId = 1,
                    },
                    new Product
                    {
                        ProductId = 3,
                        Name = "Tea",
                        Price = 1.49m,
                        CategoryId = 1,
                    },
                    new Product
                    {
                        ProductId = 4,
                        Name = "Muffin",
                        Price = 1.99m,
                        CategoryId = 2,
                    },
                    new Product
                    {
                        ProductId = 5,
                        Name = "Donut",
                        Price = 0.99m,
                        CategoryId = 2,
                    },
                    new Product
                    {
                        ProductId = 6,
                        Name = "Croissant",
                        Price = 2.00m,
                        CategoryId = 2,
                    },
                    new Product
                    {
                        ProductId = 7,
                        Name = "Egg and Cheese Sandwich",
                        Price = 3.99m,
                        CategoryId = 3,
                    },
                    new Product
                    {
                        ProductId = 8,
                        Name = "Ham and Cheese Sandwich",
                        Price = 3.49m,
                        CategoryId = 3,
                    },
                    new Product
                    {
                        ProductId = 9,
                        Name = "Cake Pop",
                        Price = 0.49m,
                        CategoryId = 4,
                    },
                    new Product
                    {
                        ProductId = 10,
                        Name = "Chips",
                        Price = 0.99m,
                        CategoryId = 4,
                    },
                }
            );
    }
}
