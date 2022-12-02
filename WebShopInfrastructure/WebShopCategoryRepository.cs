using WebShopApplication.DTOs;
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

    public List<Category> GetAllCategories(CategoryGetAllDto deleteAt, CategoryGetAllDto updatedAt)
    {
        var graterThenDelete =
            from upd in updatedAt
            from del in deleteAt 
            where upd < del
            select upd;
        foreach (var s in graterThenDelete)
        {
            return _context.CategoryTable.ToList();
        }
        //return _context.CategoryTable.ToList();
        return null;
    }

    Category IWebShopCategoryRepository.DeleteCategory(int id, CategorySingleEditModel category)
    {
        var d = _context.CategoryTable.Find(id);
        d.DeletedAt = category.DeletedAt;
        _context.CategoryTable.Update(d);
        _context.SaveChanges();
        return d;
    }

    public void RebuildDB()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
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