using Coffee_Shop_POS.Controllers;
using Coffee_Shop_POS.Models;
using Coffee_Shop_POS.Views;
using Spectre.Console;

namespace Coffee_Shop_POS.Services;

public class CategoryService
{
    internal static void InsertCategory()
    {
        var category = new Category();
        
        category.Name = AnsiConsole.Ask<string>("Enter Category Name:");
        
        CategoryController.AddCategory(category);
    }
    
    internal static void GetAllCategories()
    {
        var categories = CategoryController.GetAllCategories();
        
        UserInterface.ShowCategoryTable(categories);
    }
}