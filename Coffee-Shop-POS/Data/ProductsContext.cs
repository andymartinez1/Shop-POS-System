using Coffee_Shop_POS.Models;
using Microsoft.EntityFrameworkCore;

namespace Coffee_Shop_POS.Data;

public class ProductsContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("Data Source = products.db");
}