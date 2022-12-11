using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopOptionGroupRepository
{
    OptionGroup CreateNewOptionGroup(OptionGroup option);
    
    List<OptionGroup> GetAllOptionGroups();
}