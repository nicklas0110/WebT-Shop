using Microsoft.AspNetCore.Mvc;
using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class OptionGroupController : ControllerBase
{
    private IWebShopService _webShopService;
    private IWebShopOptionGroupRepository _webShopOptionGroupRepository;

    
    public OptionGroupController(IWebShopService webShopService,IWebShopOptionGroupRepository webShopOptionGroup)
    {
        _webShopService = webShopService;
        _webShopOptionGroupRepository = webShopOptionGroup;
    }
    
    [HttpGet]
    [Route("")]
    public ActionResult<List<OptionGroup>> GetAllOptionGroups()
    {
        return _webShopService.GetAllOptionGroups();
    }
    
    
    
}