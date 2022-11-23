using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopCategoryRepository
{
    Category[] GetAllCat();
    
    Category CreateNewCategory(Category category);
    
    List<Category> GetAllCategories();
}