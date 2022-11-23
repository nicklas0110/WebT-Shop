using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopInfrastructure;

public class WebShopOptionRepository : IWebShopOptionRepository
{
    private readonly WebShopDbContext _context; 
    
    public WebShopOptionRepository(WebShopDbContext context)
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
        return _context.OptionTable.ToList();
    }
}