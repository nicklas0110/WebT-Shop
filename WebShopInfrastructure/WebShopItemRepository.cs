using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopInfrastructure;

public class WebShopRepository : IWebShopItemRepository
{
    private readonly DatabaseContext _context; 
    
    public WebShopRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public List<Item> GetAllItems()
    {
        return _context.ItemTable.Where(x => x.DeletedAt == null || x.CreatedAt >= x.DeletedAt).ToList();
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

    public Item UpdateItem(int id, Item tShirt)
    {
        _context.ItemTable.Update(tShirt);
        _context.SaveChanges();
        return tShirt;
    }

    public Item DeleteUpdateItem(int id, ItemSingleEditModel item)
    {
        var d = _context.ItemTable.Find(id);
        d.DeletedAt = item.DeletedAt;
        _context.ItemTable.Update(d);
        _context.SaveChanges();
        return d;
    }

    
    
}