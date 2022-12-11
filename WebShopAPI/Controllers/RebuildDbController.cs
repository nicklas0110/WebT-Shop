using Microsoft.AspNetCore.Mvc;
using WebShopApplication.Interfaces;

namespace WebShopAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RebuildDbController : ControllerBase
{
    private IWebShopService _webShopService;
    private IAuthenticationService _authenticationService;

    public RebuildDbController(IWebShopService webShopService,IAuthenticationService authenticationService)
    {
        _webShopService = webShopService;
        _authenticationService = authenticationService;
    }
    
    [HttpGet]
    [Route("")]
    public void RebuildDB()
    {
        _webShopService.RebuildDB();
    }
}