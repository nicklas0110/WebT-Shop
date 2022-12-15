using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopInfrastructure;

public class ItemOptionRepositoryRepository : IItemOptionRepository
{
    private readonly DatabaseContext _context;

    public ItemOptionRepositoryRepository(DatabaseContext context)
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

    public List<ItemOption> GetByItemIds(List<int> itemIds)
    {
        return _context.ItemOptionTable
            .Where(io => io.DeletedAt == null || io.DeletedAt > DateTime.UtcNow)
            .Where(io => itemIds.Contains(io.ItemId))
            .ToList();
    }

    public void DeleteItemOption(int id)
    {
        var itemOption = _context.ItemOptionTable.Find(id);
        itemOption.DeletedAt = DateTime.UtcNow;
        _context.ItemOptionTable.Update(itemOption);
        _context.SaveChanges();
    }
}