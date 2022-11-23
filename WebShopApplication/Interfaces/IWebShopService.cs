using WebShopApplication.DTOs;
using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopService
{
    List<Item> GetAllItems();
    Item CreateNewItem(WebShopDTOs dto);
    Item GetItemById(int id);
    void RebuildDB();
    Item UpdateItem(int id, Item product);
    Item DeleteItem(int id);
    Category CreateNewCategory(WebShopDTOsCategory dto);
    List<Category> GetAllCategories();

}