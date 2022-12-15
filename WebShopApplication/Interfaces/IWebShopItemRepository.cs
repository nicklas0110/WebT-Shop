using WebShopApplication.DTOs;
using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopItemRepository
{
    List<Item> GetAllItems();
    Item CreateNewItem(Item tShirt);
    Item GetItemById(int id);
    Item UpdateItem(int id, Item item);
    Item DeleteUpdateItem(int id);
    
    
}