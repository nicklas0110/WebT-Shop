using WebShopApplication.DTOs;
using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopCategoryRepository
{
    Category CreateNewCategory(Category category);
    
    List<Category> GetAllCategories(CategoryGetAllDto deleteAt, CategoryGetAllDto updatedAt);
    
    Category UpdateCategory(Category category);
    
    Category DeleteCategory(int id, CategorySingleEditModel category);
    void RebuildDB();
}