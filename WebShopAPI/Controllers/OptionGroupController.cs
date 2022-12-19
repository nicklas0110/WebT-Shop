using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class OptionGroupController : ControllerBase
{
    private IWebShopService _webShopService;
    private IWebShopOptionGroupRepository _webShopOptionGroupRepository;

    
    public OptionGroupController(IWebShopService webShopService,IWebShopOptionGroupRepository webShopOptionGroup)
    {
        _webShopService = webShopService;
        _webShopOptionGroupRepository = webShopOptionGroup;
    }
    
    [HttpGet]
    [Route("")]
    public ActionResult<List<OptionGroupDTO>> GetAllOptionGroups()
    {
        return _webShopService.GetAllOptionGroups();
    }
    
    [Authorize("AdminPolicy")]
    [HttpPost]  
    [Route("")]
    public ActionResult<OptionGroup> CreateNewOptionGroup(OptionGroupPostModel postModel)
    {
        try
        {
            var dto = new OptionGroupDTO(postModel);
            var result = _webShopService.CreateNewOptionGroup(dto);
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
    public ActionResult<OptionGroup> UpdateOptionGroups([FromRoute] int id, [FromBody] OptionGroup optionGroup)
    {
        try
        {
            return Ok(_webShopService.UpdateOptionGroups(id, optionGroup));
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
    public ActionResult<Item> DeleteUpdateOptionGroups([FromRoute] int id)
    {
        try
        {
            return Ok(_webShopService.DeleteOptionGroups(id));
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
    [HttpGet]
    [Route("with-options")]
    public ActionResult<List<OptionGroupDTO>> GetAllOptionGroupsWithOptions()
    {
        try
        {
            return Ok(_webShopService.GetAllOptionGroupsWithOptions());
        }
        catch (KeyNotFoundException e)
        {
            return NotFound("No product found at groupDtos ");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }
}