using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopOptionRepository
{
    Option CreateNewOption(Option option);
    
    List<Option> GetAllOptions();
    
    Option UpdateOption(Option option);
    
    Option DeleteOption(int id);
}