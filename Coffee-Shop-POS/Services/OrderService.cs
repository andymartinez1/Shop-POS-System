using Coffee_Shop_POS.Controllers;
using Coffee_Shop_POS.Models;
using Coffee_Shop_POS.Models.DTO;
using Coffee_Shop_POS.Views;
using Spectre.Console;

namespace Coffee_Shop_POS.Services;

public class OrderService
{
    internal static void InsertOrder()
    {
        var orderProducts = GetProductsForOrder();
        OrderController.AddOrder(orderProducts);
    }

    internal static void GetAllOrders()
    {
        var orders = OrderController.GetOrders();
        UserInterface.ShowOrderTable(orders);
    }

    internal static void GetOrderById()
    {
        var order = GetOrderOptionInput();
        var products = order
            .OrderProducts.Select(x => new ProductForOrderViewDTO
            {
                Id = x.ProductId,
                Name = x.Product.Name,
                CategoryName = x.Product.Category.Name,
                Quantity = x.Quantity,
                Price = x.Product.Price,
                TotalPrice = x.Quantity * x.Product.Price,
            })
            .ToList();

        UserInterface.ShowOrder(order);
        UserInterface.ShowOrderProductsTable(products);
    }

    private static Order GetOrderOptionInput()
    {
        var orders = OrderController.GetOrders();

        var ordersArray = orders.Select(x => $"{x.Id}.{x.OrderDate} - {x.TotalPrice}").ToArray();
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>().Title("Choose Order:").AddChoices(ordersArray)
        );

        var idArray = option.Split('.');
        var order = orders.Single(o => o.Id == Int32.Parse(idArray[0]));

        return order;
    }

    private static List<OrderProduct> GetProductsForOrder()
    {
        var products = new List<OrderProduct>();
        var order = new Order { OrderDate = DateTime.Now };

        bool isOrderFinished = false;
        while (!isOrderFinished)
        {
            var product = ProductService.GetProductOptionInput();
            var quantity = AnsiConsole.Ask<int>("Enter Quantity:");

            order.TotalPrice = order.TotalPrice + (product.Price * quantity);

            products.Add(
                new OrderProduct
                {
                    Order = order,
                    ProductId = product.ProductId,
                    Quantity = quantity,
                }
            );

            isOrderFinished = !AnsiConsole.Confirm("Would you like to add more products?");
        }

        return products;
    }
}
