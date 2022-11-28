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
    private IWebShopItemRepository _webShopItemRepository;
    private IWebShopCategoryRepository _webShopCategoryRepository;
    private IWebShopOptionRepository _webShopOptionRepository;
    
    public WebShopController(IWebShopService webShopService,IWebShopItemRepository webShopItemRepository)
    {
        _webShopService = webShopService;
        _webShopItemRepository = webShopItemRepository;
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
        _webShopItemRepository.RebuildDB();
        
    }
    
    [HttpPut]
    [Route("Item/{id}")] //localhost:5111/box/8732648732
    public ActionResult<Item> UpdateItem([FromRoute] int id, [FromBody] Item item)
    {
        try
        {
            return Ok(_webShopService.UpdateItem(id, item));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound("No product found at ID " + id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }
    [HttpPut]
    [Route("Category/{id}")] //localhost:5111/box/8732648732
    public ActionResult<Category> UpdateCategory([FromRoute] int id, [FromBody] Category category)
    {
        try
        {
            return Ok(_webShopService.UpdateCategory(id, category));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound("No product found at ID " + id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }
    [HttpPut]
    [Route("Option/{id}")] //localhost:5111/box/8732648732
    public ActionResult<Option> UpdateOption([FromRoute] int id, [FromBody] Option option)
    {
        try
        {
            return Ok(_webShopService.UpdateOption(id, option));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound("No product found at ID " + id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }
    
}