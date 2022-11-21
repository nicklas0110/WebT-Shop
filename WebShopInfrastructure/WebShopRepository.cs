using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopInfrastructure;

public class WebShopRepository : IWebShopRepository
{
    private readonly WebShopDbContext _context; 
    
    public WebShopRepository(WebShopDbContext context)
    {
        _context = context;
    }
    
    public List<TShirt> GetAllTShirts()
    {
        return _context.BoxTable.ToList();
    }

    public TShirt CreateNewTShirt(TShirt tShirt)
    {
        _context.BoxTable.Add(tShirt);
        _context.SaveChanges();
        return tShirt;
    }

    public TShirt GetTShirtById(int id)
    {
        throw new NotImplementedException();
    }

    public void RebuildDB()
    {
        throw new NotImplementedException();
    }

    public TShirt UpdateTShirt(TShirt tShirt)
    {
        throw new NotImplementedException();
    }

    public TShirt DeleteTShirt(int id)
    {
        throw new NotImplementedException();
    }

    public TShirt[] GetAll()
    {
        throw new NotImplementedException();
    }
}