using WebShopApplication.DTOs;
using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopServiceItem
{
    List<ItemDTO> GetAllItems();
    List<ItemDTO> GetAllItemWithFilter(int? categoryId, List<List<int>> optionIds);
    ItemDTO CreateNewItem(ItemDTO dto);
    Item GetItemById(int id);
    void RebuildDB();
    void SeedData();
    ItemDTO UpdateItem(int id, ItemDTO item);
    object? DeleteUpdateItem(int id);
}