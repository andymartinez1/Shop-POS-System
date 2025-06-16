using Coffee_Shop_POS.Models;
using Coffee_Shop_POS.Models.DTO;
using Spectre.Console;

namespace Coffee_Shop_POS.Views;

public class UserInterface
{
    internal static void ShowProductTable(List<Product> products)
    {
        var table = new Table();
        table.AddColumn("ProductId");
        table.AddColumn("Name");
        table.AddColumn("Price");
        table.AddColumn("Category");

        foreach (var product in products)
        {
            table.AddRow(
                product.ProductId.ToString(),
                product.Name,
                product.Price.ToString(),
                product.Category.Name
            );
        }

        AnsiConsole.Write(table);
    }

    public static void ShowProduct(Product product)
    {
        var panel = new Panel(
            $@"ProductId: {product.ProductId} 
Name: {product.Name}
Category: {product.Category.Name}"
        );
        panel.Header = new PanelHeader("Product Information: ");
        panel.Padding = new Padding(2);

        AnsiConsole.Write(panel);
    }

    public static void ShowCategoryTable(List<Category> categories)
    {
        var table = new Table();
        table.AddColumn("CategoryId");
        table.AddColumn("Name");

        foreach (var category in categories)
        {
            table.AddRow(category.CategoryId.ToString(), category.Name);
        }

        AnsiConsole.Write(table);
    }

    public static void ShowCategory(Category category)
    {
        var panel = new Panel(
            $@"CategoryId: {category.CategoryId}
Name: {category.Name}
Product Count: {category.Products.Count}"
        );
        panel.Header = new PanelHeader($"{category.Name}");
        panel.Padding = new Padding(2);

        AnsiConsole.Write(panel);

        ShowProductTable(category.Products);
    }

    public static void ShowOrderTable(List<Order> orders)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Date");
        table.AddColumn("Count");
        table.AddColumn("Total Price");

        foreach (var order in orders)
        {
            table.AddRow(
                order.Id.ToString(),
                order.OrderDate.ToString(),
                order.OrderProducts.Sum(x => x.Quantity).ToString(),
                order.TotalPrice.ToString()
            );
        }

        AnsiConsole.Write(table);
    }

    public static void ShowOrder(Order order)
    {
        var panel = new Panel(
            $@"Id: {order.Id}
Date: {order.OrderDate}
Product Count: {order.OrderProducts.Sum(x => x.Quantity)}"
        );
        panel.Header = new PanelHeader($"Order Number: {order.Id}");
        panel.Padding = new Padding(2);

        AnsiConsole.Write(panel);
    }

    public static void ShowOrderProductsTable(List<ProductForOrderViewDTO> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Category");
        table.AddColumn("Quantity");
        table.AddColumn("Price");
        table.AddColumn("Total");

        foreach (var product in products)
        {
            table.AddRow(
                product.Id.ToString(),
                product.Name,
                product.CategoryName,
                product.Quantity.ToString(),
                product.Price.ToString("C"),
                product.TotalPrice.ToString("C")
            );
        }

        table.AddRow("", "", "", "", "", "");
        table.AddRow("", "", "", "", "Total:", $"{products.Sum(x => x.TotalPrice).ToString("C")}");

        AnsiConsole.Write(table);
    }

    public static void ShowReportByMonth(List<MonthlyReportDTO> report)
    {
        var table = new Table();
        table.AddColumn("Month");
        table.AddColumn("Total Quantity");
        table.AddColumn("Total Price");

        foreach (var item in report)
        {
            table.AddRow(item.Month, item.TotalQuantity.ToString(), item.TotalPrice.ToString("C"));
        }

        AnsiConsole.Write(table);
    }
}
