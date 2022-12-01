using Microsoft.AspNetCore.Mvc;
using WebShopApplication.Interfaces;

namespace WebShopAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RebuildDbController : ControllerBase
{
    private IWebShopService _webShopService;

    public RebuildDbController(IWebShopService webShopService)
    {
        _webShopService = webShopService;
    }
    
    [HttpGet]
    [Route("")]
    public void RebuildDB()
    {
        _webShopService.RebuildDB();

    }
}