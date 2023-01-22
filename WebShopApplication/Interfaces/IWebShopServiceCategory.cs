using WebShopApplication.DTOs;
using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopServiceCategory
{
    ItemCategoryDTO CreateNewCategory(ItemCategoryDTO dto);
    List<ItemCategoryDTO> GetAllCategories();
    Category UpdateCategory(int id, Category category);
    Category DeleteCategory(int id);
    
}