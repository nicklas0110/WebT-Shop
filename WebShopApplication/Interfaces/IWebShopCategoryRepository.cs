using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopCategoryRepository
{
    Category CreateNewCategory(Category category);
    
    List<Category> GetAllCategories();
    
    Category UpdateCategory(Category category);
    
    Category DeleteCategory(int id);
}