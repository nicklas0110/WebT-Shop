using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopRepository
{
    List<Item> GetAllItems();
    Item CreateNewItem(Item tShirt);
    Item GetItemById(int id);
    void RebuildDB();
    Item UpdateItem(Item tShirt);
    Item DeleteItem(int id);

    Item[] GetAll();
    
    Category[] GetAllCat();
    
    Category CreateNewCategory(Category category);
    List<Category> GetAllCategories();
    
    Option CreateNewOption(Option option);
    List<Option> GetAllOptions();
}