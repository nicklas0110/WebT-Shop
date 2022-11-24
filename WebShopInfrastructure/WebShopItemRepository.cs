using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopInfrastructure;

public class WebShopRepository : IWebShopItemRepository
{
    private readonly WebShopDbContext _context; 
    
    public WebShopRepository(WebShopDbContext context)
    {
        _context = context;
    }
    
    public List<Item> GetAllItems()
    {
        return _context.ItemTable.ToList();
    }

    public Item CreateNewItem(Item item)
    {
        _context.ItemTable.Add(item);
        _context.SaveChanges();
        return item;
    }

    public Item GetItemById(int id)
    {
        throw new NotImplementedException();
    }

    public void RebuildDB()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }

    public Item UpdateItem(Item item)
    {
        throw new NotImplementedException();
    }

    public Item DeleteItem(int id)
    {
        throw new NotImplementedException();
    }
    
}