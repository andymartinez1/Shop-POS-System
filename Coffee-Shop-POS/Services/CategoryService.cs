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

    internal static void UpdateCategory()
    {
        var category = GetCategoryOptionInput();

        category.Name = AnsiConsole.Ask<string>("Update Category Name:");

        CategoryController.UpdateCategory(category);
    }

    internal static void DeleteCategory()
    {
        var category = GetCategoryOptionInput();

        CategoryController.DeleteCategory(category);
    }

    internal static void GetCategoryById()
    {
        var category = GetCategoryOptionInput();

        UserInterface.ShowCategory(category);
    }

    internal static void GetAllCategories()
    {
        var categories = CategoryController.GetAllCategories();

        UserInterface.ShowCategoryTable(categories);
    }

    internal static Category GetCategoryOptionInput()
    {
        var categories = CategoryController.GetAllCategories();

        var categoriesArray = categories.Select(c => c.Name).ToArray();
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>().Title("Choose Category:").AddChoices(categoriesArray)
        );

        var category = categories.Single(c => c.Name == option);

        return category;
    }
}
