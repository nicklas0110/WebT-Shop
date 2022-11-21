using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WebShopController : ControllerBase
{
    private IWebShopService _webShopService;

    public WebShopController(IWebShopService webShopService)
    {
        _webShopService = webShopService;
    }
    
    [HttpGet]
    [Route("")]
    public ActionResult<List<TShirt>> GetAllTShirt()
    {
        return _webShopService.GetAllNTShirts();
    }
    
    [HttpPost]  
    [Route("")]
    public ActionResult<TShirt> CreateNewTShirt(WebShopDTOs dto)
    {
        try
        {
            var result = _webShopService.CreateNewTShirt(dto);
            return Created("", result);
        }
        catch (ValidationException v)
        {
            return BadRequest(v.Message);
        }
        catch (System.Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
}