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

    Category IWebShopCategoryRepository.DeleteCategory(int id)
    {
        throw new NotImplementedException();
    }

    public Category UpdateCategory(Category category)
    {
        _context.CategoryTable.Update(category);
        _context.SaveChanges();
        return category;
    }

    public Item DeleteCategory(int id)
    {
        throw new NotImplementedException();
    }
}