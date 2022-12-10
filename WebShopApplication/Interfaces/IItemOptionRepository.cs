using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IItemOptionRepository
{
    public void CreateItemOptions(List<ItemOption> itemOptions);
}