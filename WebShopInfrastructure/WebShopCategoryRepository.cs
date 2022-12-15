using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopInfrastructure;

public class WebShopCategoryRepository : IWebShopCategoryRepository
{
    private readonly DatabaseContext _context; 
    
    public WebShopCategoryRepository(DatabaseContext context)
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
         _context.CategoryTable.Where(x => x.UpdatedAt <= x.UpdatedAt);
         //  filteredOwners= _context.Orders.Include(o => o.Customer).Include(p => p.DateForOrderToBeCompleted).OrderByDescending(c => c.ID).Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage).ToList();

         
         return  _context.CategoryTable.Where(x => x.DeletedAt == null || x.CreatedAt >= x.DeletedAt).ToList();
    }

    Category IWebShopCategoryRepository.DeleteCategory(int id)
    {
        var c = _context.CategoryTable.Find(id);
        c.DeletedAt = DateTime.UtcNow;
        _context.CategoryTable.Update(c);
        _context.SaveChanges();
        return c;
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