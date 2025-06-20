﻿using Coffee_Shop_POS.Data;
using Coffee_Shop_POS.Models;
using Microsoft.EntityFrameworkCore;

namespace Coffee_Shop_POS.Controllers;

public class ProductController
{
    public static void AddProduct(Product product)
    {
        using var db = new ProductsContext();
        db.Add(product);
        db.SaveChanges();
    }

    public static void UpdateProduct(Product product)
    {
        using var db = new ProductsContext();
        db.Update(product);
        db.SaveChanges();
    }

    public static void DeleteProduct(Product product)
    {
        using var db = new ProductsContext();
        db.Remove(product);
        db.SaveChanges();
    }

    public static Product GetProductById(int id)
    {
        using var db = new ProductsContext();
        var product = db.Products.Include(p => p.Category).SingleOrDefault(p => p.ProductId == id);

        return product;
    }

    public static List<Product> GetAllProducts()
    {
        using var db = new ProductsContext();
        var products = db.Products.Include(p => p.Category).ToList();
        return products;
    }
}
