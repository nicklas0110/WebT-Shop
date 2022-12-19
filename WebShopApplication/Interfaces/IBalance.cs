using WebShopApplication.DTOs;

namespace WebShopApplication.Interfaces;

public interface IBalance
{
    public string AddBalance(int userId, int balance);
    public string RemoveBalance(int userId, int balance);
}