using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopInfrastructure;

public class ItemOptionRepository : IItemOption
{
    private readonly DatabaseContext _context;

    public ItemOptionRepository(DatabaseContext context)
    {
        _context = context;
    }

    public void CreateItemOptions(List<ItemOption> itemOptions)
    {
        foreach (var itemOption in itemOptions)
        {
            _context.ItemOptionTable.Add(itemOption);
            _context.SaveChanges();
        }
    }
}