using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopOptionRepository
{
    Option CreateNewOption(Option option);
    
    List<Option> GetAllOptions();
}