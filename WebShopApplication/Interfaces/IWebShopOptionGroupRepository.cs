using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopOptionGroupRepository
{
    OptionGroup CreateNewOptionGroup(OptionGroup option);
    List<OptionGroup> GetAllOptionGroups();
    OptionGroup UpdateOptionGroups(OptionGroup optionGroup);
    OptionGroup DeleteOptionGroups(int id);
}