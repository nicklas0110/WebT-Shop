using Microsoft.AspNetCore.Mvc;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;

namespace WebShopAPI.Controllers;

[ApiController]
[Route("controller")]
public class AuthController : ControllerBase
{
    private readonly IAuthenticationService _auth;
    
    public AuthController(IAuthenticationService auth)
    {
        _auth = auth;
    }
    
    [HttpPost]
    [Route("login")]
    public ActionResult Login(LoginAndRegisterDTO dto)
    {
        try
        {
            return Ok(_auth.Login(dto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    [Route("register")]
    public ActionResult Register(LoginAndRegisterDTO dto)
    {
        try
        {
            return Ok(_auth.Register(dto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}