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
    [Route("Item")]
    public ActionResult<List<Item>> GetAllTItems()
    {
        return _webShopService.GetAllItems();
    }
    
    [HttpPost]  
    [Route("Item")]
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
    
    [HttpGet]
    [Route("Option")]
    public ActionResult<List<Option>> GetAllOptions()
    {
        return _webShopService.GetAllOptions();
    }
    
    [HttpPost]  
    [Route("Option")]
    public ActionResult<Category> CreateNewOption(OptionDTOs dtoOption)
    {
        try
        {
            var result = _webShopService.CreateNewOption(dtoOption);
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
    [Route("RebuildDB")]
    public void RebuildDB()
    {
        _webShopService.RebuildDB();
    }
}