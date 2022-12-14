using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopInfrastructure;

public class WebShopOptionRepository : IWebShopOptionRepository
{
    private readonly DatabaseContext _context; 
    
    public WebShopOptionRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Option CreateNewOption(Option option)
    {
        _context.OptionTable.Add(option);
        _context.SaveChanges();
        return option;
    }

    public List<Option> GetAllOptions()
    {
        return  _context.OptionTable.Where(x => x.DeletedAt == null || x.CreatedAt >= x.DeletedAt).ToList();
    }

    public List<Option> GetOptionsByIds(List<int> optionIds)
    {
        return _context.OptionTable.Where(o => optionIds.Contains(o.Id)).ToList();
    }

    public Option UpdateOption(Option option)
    {
        _context.OptionTable.Update(option);
        _context.SaveChanges();
        return option;
    }

    public Option DeleteOption(int id)
    {
        var o = _context.OptionTable.Find(id);
        o.DeletedAt = DateTime.UtcNow;
        _context.OptionTable.Update(o);
        _context.SaveChanges();
        return o;
    }
    

    public void RebuildDB()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }
}