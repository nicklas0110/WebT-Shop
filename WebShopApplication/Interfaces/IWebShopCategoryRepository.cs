using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopCategoryRepository
{
    Category CreateNewCategory(Category category);
    
    List<Category> GetAllCategories();
}