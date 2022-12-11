using WebShopApplication.DTOs;

namespace WebShopApplication.Interfaces;

public interface IAuthenticationService
{
    public string Register(LoginAndRegisterDTO dto);
    public string Login(LoginAndRegisterDTO dto);
}