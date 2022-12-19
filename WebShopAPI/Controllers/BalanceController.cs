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
    public ActionResult AddBalance(int userId, [FromQuery] int balance)
    {
        try
        {
            _repo.AddBalance(userId, balance);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    [Route("removeBalance/{userId:int}")]
    public ActionResult RemoveBalance(int userId, [FromQuery] int balance)
    {
        try
        {
            _repo.RemoveBalance(userId, balance);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}