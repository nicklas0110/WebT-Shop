using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopInfrastructure;

public class WebShopOptionGroupRepository : IOptionGroupRepository
{
    private readonly DatabaseContext _context;
    
    public WebShopOptionGroupRepository(DatabaseContext context)
    {
        _context = context;
    }


    public List<OptionGroup> GetAllOptionGroups()
    {
        return _context.OptionGroupTable.Where(x => x.DeletedAt == null || x.CreatedAt >= x.DeletedAt).ToList();
    }

    public OptionGroup CreateOptionGroups(OptionGroup optionGroup)
    {
        _context.OptionGroupTable.Add(optionGroup);
        _context.SaveChanges();
        return optionGroup;;
    }
}