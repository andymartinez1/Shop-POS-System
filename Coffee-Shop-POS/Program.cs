using Coffee_Shop_POS.Data;
using Coffee_Shop_POS.Views;

var context = new ProductsContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

Menu.MainMenu();
