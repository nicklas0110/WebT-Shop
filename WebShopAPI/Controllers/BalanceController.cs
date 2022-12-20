using Microsoft.AspNetCore.Mvc;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebShopInfrastructure;
using WebsShopDomain;

namespace WebShopAPI.Controllers;

public class BalanceController : ControllerBase
{
    private readonly IUserRepository _repo;

    public BalanceController(IUserRepository userRepository)
    {
        _repo = userRepository;
    }
    
    [HttpPost]
    [Route("addBalance/{userId:int}")]
    public ActionResult<int> AddBalance(int userId, [FromQuery] int balance)
    {
        try
        {
            var result = _repo.AddBalance(userId, balance);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    [Route("removeBalance/{userId:int}")]
    public ActionResult<int> RemoveBalance(int userId, [FromQuery] int balance)
    {
        try
        {
            var result = _repo.RemoveBalance(userId, balance);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("balance/{userId:int}")]
    public ActionResult<int> GetBalance(int userId)
    {
        try
        {
            var result = _repo.GetBalance(userId);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}