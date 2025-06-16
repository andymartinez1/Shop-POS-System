using Coffee_Shop_POS.Data;
using Coffee_Shop_POS.Models;
using Microsoft.EntityFrameworkCore;

namespace Coffee_Shop_POS.Controllers;

public class OrderController
{
    internal static void AddOrder(List<OrderProduct> orders)
    {
        using var db = new ProductsContext();
        db.OrderProducts.AddRange(orders);
        db.SaveChanges();
    }

    internal static List<Order> GetOrders()
    {
        using var db = new ProductsContext();
        var orderList = db
            .Orders.Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .ThenInclude(p => p.Category)
            .ToList();

        return orderList;
    }
}
