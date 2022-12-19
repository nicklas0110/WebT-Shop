using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IUserRepository
{
    public User GetUserByEmail(string email);
    public User CreateNewUser(User user);
    public void AddBalance(int userId, int balance);
    public void RemoveBalance(int userId, int balance);
}