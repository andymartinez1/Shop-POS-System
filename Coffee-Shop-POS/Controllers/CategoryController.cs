using Coffee_Shop_POS.Data;
using Coffee_Shop_POS.Models;
using Microsoft.EntityFrameworkCore;

namespace Coffee_Shop_POS.Controllers;

public class CategoryController
{
    internal static void AddCategory(Category category)
    {
        using var db = new ProductsContext();
        db.Add(category);
        db.SaveChanges();
    }

    internal static void UpdateCategory(Category category)
    {
        using var db = new ProductsContext();
        db.Update(category);
        db.SaveChanges();
    }

    internal static void DeleteCategory(Category category)
    {
        using var db = new ProductsContext();
        db.Remove(category);
        db.SaveChanges();
    }

    internal static void GetCategoryById() { }

    internal static List<Category> GetAllCategories()
    {
        using var db = new ProductsContext();
        var categories = db.Categories.Include(c => c.Products).ToList();
        return categories;
    }
}
