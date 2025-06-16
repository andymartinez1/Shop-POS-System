using Coffee_Shop_POS.Controllers;
using Coffee_Shop_POS.Models;
using Coffee_Shop_POS.Views;
using Spectre.Console;

namespace Coffee_Shop_POS.Services;

public class ProductService
{
    internal static void InsertProduct()
    {
        var product = new Product();
        
        product.Name = AnsiConsole.Ask<string>("Enter Product Name:");
        product.Price = AnsiConsole.Ask<decimal>("Enter Product Price:");
        ProductController.AddProduct(product);
    }

    internal static void UpdateProduct()
    {
        var product = GetProductOptionInput();

        product.Name = AnsiConsole.Confirm("Update Product Name?")
            ? product.Name = AnsiConsole.Ask<string>("Update Product Name:")
            : product.Name;
        
        product.Price = AnsiConsole.Confirm("Enter Product Price:")
            ? product.Price = AnsiConsole.Ask<decimal>("Enter Product Price:")
            : product.Price;
        
        ProductController.UpdateProduct(product);
    }

    internal static void DeleteProduct()
    {
        var product = GetProductOptionInput();
        
        ProductController.DeleteProduct(product);
    }

    private static Product GetProductOptionInput()
    {
        var products = ProductController.GetAllProducts();
        
        var productsArray = products.Select(p => p.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Product:")
            .AddChoices(productsArray));

        var productId = products.Single(p => p.Name == option).ProductId;
        var product = ProductController.GetProductById(productId);

        return product;
    }

    internal static void GetProductById()
    {
        var product = GetProductOptionInput();
        
        UserInterface.ShowProduct(product);
    }

    internal static void GetAllProducts()
    {
        var products = ProductController.GetAllProducts();
        
        UserInterface.ShowProductTable(products);
    }
}