using WebShopApplication.DTOs;
using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopOptionRepository
{
    Option CreateNewOption(Option option);

    List<Option> GetAllOptions();

    List<Option> GetOptionsByIds(List<int> optionIds);

    Option UpdateOption(Option option);
    List<Option> GetOptionByGroupId(int id);
    Option DeleteOption(int id);
}