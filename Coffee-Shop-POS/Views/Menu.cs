using Coffee_Shop_POS.Controllers;
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
            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<MenuOptions>()
                    .Title("What would you like to do?")
                    .AddChoices(
                        MenuOptions.AddProduct,
                        MenuOptions.UpdateProduct,
                        MenuOptions.DeleteProduct,
                        MenuOptions.ViewProduct,
                        MenuOptions.ViewAllProducts,
                        MenuOptions.Quit));

            switch (userChoice)
            {
                case MenuOptions.AddProduct:
                    AnsiConsole.Clear();
                    ProductService.InsertProduct();
                    break;
                case MenuOptions.UpdateProduct:
                    AnsiConsole.Clear();
                    ProductService.UpdateProduct();
                    break;
                case MenuOptions.DeleteProduct:
                    AnsiConsole.Clear();
                    ProductService.DeleteProduct();
                    break;
                case MenuOptions.ViewProduct:
                    AnsiConsole.Clear();
                    ProductService.GetProductById();
                    break;
                case MenuOptions.ViewAllProducts:
                    AnsiConsole.Clear();
                    ProductService.GetAllProducts();
                    break;
                case MenuOptions.Quit:
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
}