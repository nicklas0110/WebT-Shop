using WebShopApplication.Interfaces;

namespace WebShopInfrastructure;

public class WebShopServiceRepository : IWebShopServiceRepository
{
    
    private readonly DatabaseContext _context;

    public WebShopServiceRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public void RebuildDB()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }
}