using Coffee_Shop_POS.Models;
using Coffee_Shop_POS.Services;
using Spectre.Console;

namespace Coffee_Shop_POS.Views;

public class Menu
{
    internal static void MainMenu()
    {
        var isRunning = true;
        while (isRunning)
        {
            AnsiConsole.Clear();
            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.MainMenuOptions>()
                    .Title("What would you like to do?")
                    .AddChoices(
                        Enums.MainMenuOptions.ManageCategories,
                        Enums.MainMenuOptions.ManageProducts,
                        Enums.MainMenuOptions.ManageOrders,
                        Enums.MainMenuOptions.GenerateReport,
                        Enums.MainMenuOptions.Quit
                    )
            );

            switch (userChoice)
            {
                case Enums.MainMenuOptions.ManageCategories:
                    AnsiConsole.Clear();
                    CategoryMenu();
                    break;
                case Enums.MainMenuOptions.ManageProducts:
                    AnsiConsole.Clear();
                    ProductMenu();
                    break;
                case Enums.MainMenuOptions.ManageOrders:
                    AnsiConsole.Clear();
                    OrderMenu();
                    break;
                case Enums.MainMenuOptions.GenerateReport:
                    AnsiConsole.Clear();
                    ReportService.CreateMonthlyReport();
                    break;
                case Enums.MainMenuOptions.Quit:
                    AnsiConsole.Clear();
                    AnsiConsole.WriteLine("Goodbye!");
                    isRunning = false;
                    break;
                default:
                    AnsiConsole.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    internal static void CategoryMenu()
    {
        var isRunning = true;
        while (isRunning)
        {
            AnsiConsole.Clear();
            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.CategoryMenuOptions>()
                    .Title("What would you like to do?")
                    .AddChoices(
                        Enums.CategoryMenuOptions.AddCategory,
                        Enums.CategoryMenuOptions.UpdateCategory,
                        Enums.CategoryMenuOptions.DeleteCategory,
                        Enums.CategoryMenuOptions.ViewCategory,
                        Enums.CategoryMenuOptions.ViewAllCategories,
                        Enums.CategoryMenuOptions.BackToMainMenu
                    )
            );

            switch (userChoice)
            {
                case Enums.CategoryMenuOptions.AddCategory:
                    AnsiConsole.Clear();
                    CategoryService.InsertCategory();
                    break;
                case Enums.CategoryMenuOptions.UpdateCategory:
                    AnsiConsole.Clear();
                    CategoryService.UpdateCategory();
                    break;
                case Enums.CategoryMenuOptions.DeleteCategory:
                    AnsiConsole.Clear();
                    CategoryService.DeleteCategory();
                    break;
                case Enums.CategoryMenuOptions.ViewCategory:
                    AnsiConsole.Clear();
                    CategoryService.GetCategoryById();
                    break;
                case Enums.CategoryMenuOptions.ViewAllCategories:
                    AnsiConsole.Clear();
                    CategoryService.GetAllCategories();
                    break;
                case Enums.CategoryMenuOptions.BackToMainMenu:
                    isRunning = false;
                    break;
                default:
                    AnsiConsole.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    internal static void ProductMenu()
    {
        var isRunning = true;
        while (isRunning)
        {
            AnsiConsole.Clear();
            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.ProductMenuOptions>()
                    .Title("What would you like to do?")
                    .AddChoices(
                        Enums.ProductMenuOptions.AddProduct,
                        Enums.ProductMenuOptions.UpdateProduct,
                        Enums.ProductMenuOptions.DeleteProduct,
                        Enums.ProductMenuOptions.ViewProduct,
                        Enums.ProductMenuOptions.ViewAllProducts,
                        Enums.ProductMenuOptions.BackToMainMenu
                    )
            );

            switch (userChoice)
            {
                case Enums.ProductMenuOptions.AddProduct:
                    AnsiConsole.Clear();
                    ProductService.InsertProduct();
                    break;
                case Enums.ProductMenuOptions.UpdateProduct:
                    AnsiConsole.Clear();
                    ProductService.UpdateProduct();
                    break;
                case Enums.ProductMenuOptions.DeleteProduct:
                    AnsiConsole.Clear();
                    ProductService.DeleteProduct();
                    break;
                case Enums.ProductMenuOptions.ViewProduct:
                    AnsiConsole.Clear();
                    ProductService.GetProductById();
                    break;
                case Enums.ProductMenuOptions.ViewAllProducts:
                    AnsiConsole.Clear();
                    ProductService.GetAllProducts();
                    break;
                case Enums.ProductMenuOptions.BackToMainMenu:
                    isRunning = false;
                    break;
                default:
                    AnsiConsole.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    internal static void OrderMenu()
    {
        var isRunning = true;
        while (isRunning)
        {
            AnsiConsole.Clear();
            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.OrderMenuOptions>()
                    .Title("What would you like to do?")
                    .AddChoices(
                        Enums.OrderMenuOptions.AddOrder,
                        Enums.OrderMenuOptions.ViewOrder,
                        Enums.OrderMenuOptions.ViewAllOrders,
                        Enums.OrderMenuOptions.BackToMainMenu
                    )
            );

            switch (userChoice)
            {
                case Enums.OrderMenuOptions.AddOrder:
                    AnsiConsole.Clear();
                    OrderService.InsertOrder();
                    break;
                case Enums.OrderMenuOptions.ViewOrder:
                    AnsiConsole.Clear();
                    OrderService.GetOrderById();
                    break;
                case Enums.OrderMenuOptions.ViewAllOrders:
                    AnsiConsole.Clear();
                    OrderService.GetAllOrders();
                    break;
                case Enums.OrderMenuOptions.BackToMainMenu:
                    isRunning = false;
                    break;
                default:
                    AnsiConsole.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
