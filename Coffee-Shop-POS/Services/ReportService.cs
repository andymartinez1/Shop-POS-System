using System.Globalization;
using Coffee_Shop_POS.Controllers;
using Coffee_Shop_POS.Models.DTO;
using Coffee_Shop_POS.Views;

namespace Coffee_Shop_POS.Services;

public class ReportService
{
    internal static void CreateMonthlyReport()
    {
        var orders = OrderController.GetOrders();

        var report = orders
            .GroupBy(x => new { x.OrderDate.Month, x.OrderDate.Year })
            .Select(grp => new MonthlyReportDTO
            {
                Month =
                    $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(grp.Key.Month)}/ {grp.Key.Year}",
                TotalPrice = grp.Sum(grp => grp.TotalPrice),
                TotalQuantity = grp.Sum(x => x.OrderProducts.Sum(y => y.Quantity)),
            })
            .ToList();

        UserInterface.ShowReportByMonth(report);
    }
}
