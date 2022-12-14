using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IItemOptionRepository
{
    public void CreateItemOptions(List<ItemOption> itemOptions);

    public List<ItemOption> GetByItemIds(List<int> itemIds);
    
    public void DeleteItemOption(int id);

}