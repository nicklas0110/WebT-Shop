﻿using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private IWebShopServiceCategory _webShopServiceCat;
    private IWebShopCategoryRepository _webShopCategoryRepository;
    
    
    public CategoryController(IWebShopServiceCategory webShopServiceCat,IWebShopCategoryRepository webShopCategoryRepository)
    {
        _webShopServiceCat = webShopServiceCat;
        _webShopCategoryRepository = webShopCategoryRepository;
    }
    
    [HttpGet]
    [Route("")]
    public ActionResult<List<ItemCategoryDTO>> GetAllTCategories()
    {
        return _webShopServiceCat.GetAllCategories();
    }
    
    [Authorize("AdminPolicy")]
    [HttpPost]  
    [Route("")]
    public ActionResult<ItemCategoryDTO> CreateNewCategory(ItemCategoryPostModel postModel)
    {
        try
        {
            var dto = new ItemCategoryDTO(postModel);
            var result = _webShopServiceCat.CreateNewCategory(dto);
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
    public ActionResult<Category> UpdateCategory([FromRoute] int id, [FromBody] Category category)
    {
        try
        {
            return Ok(_webShopServiceCat.UpdateCategory(id,category));
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
    public ActionResult<Item> DeleteUpdateCategory([FromRoute] int id)
    {
        try
        {
            return Ok(_webShopServiceCat.DeleteCategory(id));
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