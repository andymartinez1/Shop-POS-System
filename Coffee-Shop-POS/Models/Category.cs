using System.ComponentModel.DataAnnotations;

namespace Coffee_Shop_POS.Models;

public class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; }

    public List<Product> Products { get; set; }
}
