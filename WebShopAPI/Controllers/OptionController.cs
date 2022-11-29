using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OptionController : ControllerBase
{
    private IWebShopService _webShopService;
    private IWebShopItemRepository _webShopItemRepository;
    private IWebShopCategoryRepository _webShopCategoryRepository;
    private IWebShopOptionRepository _webShopOptionRepository;
    
    public OptionController(IWebShopService webShopService,IWebShopOptionRepository webShopOptionRepository)
    {
        _webShopService = webShopService;
        _webShopOptionRepository = webShopOptionRepository;
    }
    
    
    
    [HttpGet]
    [Route("")]
    public ActionResult<List<Option>> GetAllOptions()
    {
        return _webShopService.GetAllOptions();
    }
    
    [HttpPost]  
    [Route("")]
    public ActionResult<Option> CreateNewOption(ItemOptionPostModel postModel)
    {
        try
        {
            var dto = new OptionDTOs(postModel);
            var result = _webShopService.CreateNewOption(dto);
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