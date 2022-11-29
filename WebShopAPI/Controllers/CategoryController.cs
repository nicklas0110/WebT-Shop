using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private IWebShopService _webShopService;
    private IWebShopItemRepository _webShopItemRepository;
    private IWebShopCategoryRepository _webShopCategoryRepository;
    private IWebShopOptionRepository _webShopOptionRepository;
    
    public CategoryController(IWebShopService webShopService,IWebShopCategoryRepository webShopCategoryRepository)
    {
        _webShopService = webShopService;
        _webShopCategoryRepository = webShopCategoryRepository;
    }
    
    [HttpGet]
    [Route("")]
    public ActionResult<List<Category>> GetAllTCategories()
    {
        return _webShopService.GetAllCategories();
    }
    
    [HttpPost]  
    [Route("")]
    public ActionResult<Category> CreateNewCategory(ItemCategoryPostModel postModel)
    {
        try
        {
            var dto = new ItemCategoryDTO(postModel);
            var result = _webShopService.CreateNewCategory(dto);
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
    [HttpPut]
    [Route("{id}")] //localhost:5111/box/8732648732
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
    
}