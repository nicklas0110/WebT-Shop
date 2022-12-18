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
        try
        { 
            return _webShopService.GetAllOptions();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet]
    [Route("GetByGroupId")]
    public ActionResult<List<Option>> GetOptionByGroupId(int id)
    {
        try
        { 
            return _webShopService.GetOptionByGroupId(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    
    [HttpPost]  
    [Route("")]
    public ActionResult<Option> CreateNewOption(ItemOptionPostModel postModel)
    {
        try
        {
            var dto = new OptionDTO(postModel);
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
    [Route("Edit/{id}")] //localhost:5111/box/8732648732
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
    
    [HttpPut]
    [Route("Delete/{id}")] //localhost:5111/box/8732648732
    public ActionResult<Item> DeleteUpdateOption([FromRoute] int id)
    {
        try
        {
            return Ok(_webShopService.DeleteOption(id));
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