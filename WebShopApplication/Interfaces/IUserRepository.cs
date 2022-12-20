using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IUserRepository
{
    public User GetUserByEmail(string email);
    public User CreateNewUser(User user);
    public int AddBalance(int userId, int balance);
    public int RemoveBalance(int userId, int balance);
    int GetBalance(int userId);
}