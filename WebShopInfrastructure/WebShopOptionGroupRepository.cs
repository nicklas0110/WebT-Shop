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
    
    public OptionGroup CreateNewOptionGroup(OptionGroup option)
    {
        throw new NotImplementedException();
    }

    public List<OptionGroup> GetAllOptionGroups()
    {
        return  _context.OptionGroupTable.Where(x => x.DeletedAt == null || x.CreatedAt >= x.DeletedAt).ToList();
    }
}