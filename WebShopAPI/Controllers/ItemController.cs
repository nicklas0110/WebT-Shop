using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private IWebShopService _webShopService;
    private IWebShopItemRepository _webShopItemRepository;

    
    public ItemController(IWebShopService webShopService,IWebShopItemRepository webShopItemRepository)
    {
        _webShopService = webShopService;
        _webShopItemRepository = webShopItemRepository;
    }
    
    [HttpGet]
    [Route("")]
    public ActionResult<List<ItemDTO>> GetAllTItems()
    {
        return _webShopService.GetAllItems();
    }
    
    [HttpPost]  
    [Route("")]
    public ActionResult<Item> CreateNewItem(ItemPostModel postModel)
    {
        try
        {
            var dto = new ItemDTO(postModel);
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
    [HttpPut]
    [Route("Edit/{id}")] //localhost:5111/box/8732648732
    public ActionResult<Item> UpdateItem([FromRoute] int id, [FromBody] ItemEditModel editModel)
    {
        try
        {
            var dto = new ItemDTO(editModel);
            return Ok(_webShopService.UpdateItem(id, dto));
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
    public ActionResult<Item> DeleteUpdateItem([FromRoute] int id)
    {
        try
        {
            return Ok(_webShopService.DeleteUpdateItem(id));
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