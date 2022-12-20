namespace WebShopApplication.DTOs;

public class LoginAndRegisterDTO
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Role { get; set; }
    public int Balance { get; set; }
}