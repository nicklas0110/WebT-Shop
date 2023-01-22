using WebShopApplication.DTOs;
using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopServiceOptionGroups
{
    OptionGroupDTO CreateNewOptionGroup(OptionGroupDTO optionGroupDto);
    List<OptionGroup> GetAllOptionGroups();
    OptionGroup UpdateOptionGroups(int id, OptionGroup option);
    OptionGroup DeleteOptionGroups(int id);
    List<OptionGroupDTO> GetAllOptionGroupsWithOptions();
}