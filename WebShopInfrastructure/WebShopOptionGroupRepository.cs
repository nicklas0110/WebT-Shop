using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopInfrastructure;

public class WebShopOptionGroupRepository : IWebShopOptionGroupRepository
{
    private readonly DatabaseContext _context; 
    
    public WebShopOptionGroupRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public OptionGroup CreateNewOptionGroup(OptionGroup optionGroup)
    {
        _context.OptionGroupTable.Add(optionGroup);
        _context.SaveChanges();
        return optionGroup;
    }

    public List<OptionGroup> GetAllOptionGroups()
    {
        return  _context.OptionGroupTable.Where(x => x.DeletedAt == null || x.CreatedAt >= x.DeletedAt).ToList();
    }

    public OptionGroup UpdateOptionGroups(OptionGroup optionGroup)
    {
        _context.OptionGroupTable.Update(optionGroup);
        _context.SaveChanges();
        return optionGroup;
    }

    public void RebuildDB()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }
}