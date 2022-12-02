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
    [Route("Item")]
    public ActionResult<List<Item>> GetAllTItems()
    {
        return _webShopService.GetAllItems();
    }
    
    [HttpPost]  
    [Route("Item")]
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
    [Route("Delete/{id}")] //localhost:5111/box/8732648732
    public ActionResult<Item> DeleteUpdateItem([FromRoute] int id, [FromBody] ItemSingleEditModel item)
    {
        try
        {
            return Ok(_webShopService.DeleteUpdateItem(id, item));
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