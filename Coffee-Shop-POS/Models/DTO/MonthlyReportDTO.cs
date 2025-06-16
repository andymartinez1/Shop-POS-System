namespace Coffee_Shop_POS.Models.DTO;

public class MonthlyReportDTO
{
    public string Month { get; set; }
    public decimal TotalPrice { get; set; }
    public int TotalQuantity { get; set; }
}
