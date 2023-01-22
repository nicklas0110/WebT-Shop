using WebShopApplication.DTOs;
using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopServiceOption
{
    OptionDTO CreateNewOption(OptionDTO optionDto);
    List<Option> GetAllOptions();
    Option UpdateOption(int id, Option option);
    List<Option> GetOptionByGroupId(int id);
    Option DeleteOption(int id);
}