using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OptionController : ControllerBase
{
    private IWebShopServiceOption _webShopServiceOption;
    private IWebShopOptionRepository _webShopOptionRepository;
    
    public OptionController(IWebShopServiceOption webShopService,IWebShopOptionRepository webShopOptionRepository)
    {
        _webShopServiceOption = webShopService;
        _webShopOptionRepository = webShopOptionRepository;
    }
    
    [HttpGet]
    [Route("")]
    public ActionResult<List<Option>> GetAllOptions()
    {
        try
        { 
            return _webShopServiceOption.GetAllOptions();
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
            return _webShopServiceOption.GetOptionByGroupId(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [Authorize("AdminPolicy")]
    [HttpPost]  
    [Route("")]
    public ActionResult<OptionDTO> CreateNewOption(ItemOptionPostModel postModel)
    {
        try
        {
            var dto = new OptionDTO(postModel);
            var result = _webShopServiceOption.CreateNewOption(dto);
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

    [Authorize("AdminPolicy")]
    [HttpPut]
    [Route("Edit/{id}")] //localhost:5111/box/8732648732
    public ActionResult<Option> UpdateOption([FromRoute] int id, [FromBody] Option option)
    {
        try
        {
            return Ok(_webShopServiceOption.UpdateOption(id, option));
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
    
    [Authorize("AdminPolicy")]
    [HttpPut]
    [Route("Delete/{id}")] //localhost:5111/box/8732648732
    public ActionResult<Item> DeleteUpdateOption([FromRoute] int id)
    {
        try
        {
            return Ok(_webShopServiceOption.DeleteOption(id));
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