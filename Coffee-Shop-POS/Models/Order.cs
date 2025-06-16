namespace Coffee_Shop_POS.Models;

public class Order
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public ICollection<OrderProduct> OrderProducts { get; set; }
}
