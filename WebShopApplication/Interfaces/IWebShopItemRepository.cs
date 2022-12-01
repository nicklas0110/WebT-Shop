using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopItemRepository
{
    List<Item> GetAllItems();
    Item CreateNewItem(Item tShirt);
    Item GetItemById(int id);
    void RebuildDB();
    Item UpdateItem(int id, Item tShirt);
    Item DeleteUpdateItem(int id, Item item);
    
    
}