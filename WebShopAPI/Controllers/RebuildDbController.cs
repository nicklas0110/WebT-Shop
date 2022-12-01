using Microsoft.AspNetCore.Mvc;
using WebShopApplication.Interfaces;

namespace WebShopAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RebuildDbController : ControllerBase
{
    private IWebShopService _webShopService;
    private IWebShopItemRepository _webShopItemRepository;
    private IWebShopCategoryRepository _webShopCategoryRepository;
    private IWebShopOptionRepository _webShopOptionRepository;
    
    public RebuildDbController(IWebShopService webShopService,IWebShopItemRepository webShopItemRepository)
    {
        _webShopService = webShopService;
        _webShopItemRepository = webShopItemRepository;
    }
    
    [HttpGet]
    [Route("")]
    public void RebuildDB()
    {
        _webShopItemRepository.RebuildDB();
    }
}