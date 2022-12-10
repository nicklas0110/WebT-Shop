using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IOptionGroupRepository
{
    
    List<OptionGroup> GetAllOptionGroups();
    
    OptionGroup CreateOptionGroups(OptionGroup optionGroup);
    
}