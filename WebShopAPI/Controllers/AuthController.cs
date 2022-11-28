using Microsoft.AspNetCore.Mvc;
using WebShopApplication.DTOs;

namespace WebShopAPI.Controllers;

[ApiController]
[Route("controller")]
public class AuthController : ControllerBase
{

    public AuthController()
    {
        
    }
    
    public ActionResult Login(LoginAndRegisterDTO dto)
    {
        return null;
    }
    
    public ActionResult Register(LoginAndRegisterDTO dto)
    {
        return null;
    }
}