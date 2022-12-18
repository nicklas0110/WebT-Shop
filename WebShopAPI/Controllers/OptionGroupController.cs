using FluentValidation;
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
    public ActionResult<List<OptionGroup>> GetAllOptionGroups()
    {
        return _webShopService.GetAllOptionGroups();
    }
    
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
        
    // var returnList = new List<OptionGroupDTO>();
    // var optionGroups = _webShopService.GetAllOptionGroups();
    // var options = _webShopService.GetAllOptions();
    //
    // foreach (var optionGroup in optionGroups)
    // {
    //     var optionDtos = options.Where(o => o.OptionGroupId == optionGroup.Id).Select(o => new OptionDTO(o)).ToList();
    //     var optionGroupDto = new OptionGroupDTO()
    //         { Id = optionGroup.Id, Name = optionGroup.Name, Options = optionDtos };
    //     returnList.Add(optionGroupDto);
    // }
    //
    // return returnList.Where(o => o.Options.Any()).ToList();
    }
}