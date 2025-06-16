namespace Coffee_Shop_POS.Models;

internal class Enums
{
    internal enum MainMenuOptions
    {
        ManageCategories,
        ManageProducts,
        ManageOrders,
        GenerateReport,
        Quit,
    }

    internal enum CategoryMenuOptions
    {
        AddCategory,
        UpdateCategory,
        DeleteCategory,
        ViewCategory,
        ViewAllCategories,
        BackToMainMenu,
    }

    internal enum ProductMenuOptions
    {
        AddProduct,
        UpdateProduct,
        DeleteProduct,
        ViewProduct,
        ViewAllProducts,
        BackToMainMenu,
    }

    internal enum OrderMenuOptions
    {
        AddOrder,
        ViewOrder,
        ViewAllOrders,
        BackToMainMenu,
    }
}
