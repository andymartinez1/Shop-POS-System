using Coffee_Shop_POS.Models;
using Spectre.Console;

namespace Coffee_Shop_POS.Views;

public class UserInterface
{
    internal static void ShowProductTable(List<Product> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Price");

        foreach (var product in products)
        {
            table.AddRow(
                product.Id.ToString(),
                product.Name,
                product.Price.ToString());
        }

        AnsiConsole.Write(table);
    }

    public static void ShowProduct(Product product)
    {
        var panel = new Panel($@"Id: {product.Id} 
Name: {product.Name}");
        panel.Header = new PanelHeader("Product Information: ");
        panel.Padding = new Padding(2);

        AnsiConsole.Write(panel);
    }
}