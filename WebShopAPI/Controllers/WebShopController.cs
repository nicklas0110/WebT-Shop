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
    public ActionResult<List<Item>> GetAllTItems()
    {
        return _webShopService.GetAllItems();
    }
    
    [HttpPost]  
    [Route("")]
    public ActionResult<Item> CreateNewItem(WebShopDTOs dto)
    {
        try
        {
            var result = _webShopService.CreateNewItem(dto);
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
    
    
    
    [HttpGet]
    [Route("Category")]
    public ActionResult<List<Category>> GetAllTCategories()
    {
        return _webShopService.GetAllCategories();
    }
    
    [HttpPost]  
    [Route("Category")]
    public ActionResult<Category> CreateNewCategory(WebShopDTOsCategory dtoCategory)
    {
        try
        {
            var result = _webShopService.CreateNewCategory(dtoCategory);
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