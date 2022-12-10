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
    private IOptionGroupRepository _optionGroupRepository;
    
    public OptionGroupController(IWebShopService webShopService,IOptionGroupRepository optionGroupRepository)
    {
        _webShopService = webShopService;
        _optionGroupRepository = optionGroupRepository;
    }
    
    
    
    [HttpGet]
    [Route("")]
    public ActionResult<List<OptionGroup>> GetAllOptionGroups()
    {
        return _webShopService.GetAllOptionGroups();
    }
    
    [HttpPost]  
    [Route("")]
    public ActionResult<OptionGroup> CreateNewOption(OptionGroupsPostModel postModel)
    {
        try
        {
            var dto = new OptionGroupDTO(postModel);
            var result = _webShopService.CreateOptionGroups(dto);
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