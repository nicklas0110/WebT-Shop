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
            var dto = new OptionGroupDTOs(postModel);
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
    
    
    
}