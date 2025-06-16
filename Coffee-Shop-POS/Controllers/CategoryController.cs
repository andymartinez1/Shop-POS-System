using Coffee_Shop_POS.Data;
using Coffee_Shop_POS.Models;

namespace Coffee_Shop_POS.Controllers;

public class CategoryController
{
    internal static void AddCategory(Category category)
    {
        using var db = new ProductsContext();
        db.Add(category);
        db.SaveChanges();
    }

    internal static List<Category> GetAllCategories()
    {
        using var db = new ProductsContext();
        var categories = db.Categories.ToList();
        return categories;
    }
}