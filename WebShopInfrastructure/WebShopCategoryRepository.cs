using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopInfrastructure;

public class WebShopCategoryRepository : IWebShopCategoryRepository
{
    private readonly WebShopDbContext _context; 
    
    public WebShopCategoryRepository(WebShopDbContext context)
    {
        _context = context;
    }
    public Category[] GetAllCat()
    {
        throw new NotImplementedException();
    }

    public Category CreateNewCategory(Category category)
    {
        _context.CategoryTable.Add(category);
        _context.SaveChanges();
        return category;
    }

    public List<Category> GetAllCategories()
    {
        return _context.CategoryTable.ToList();
    }
}