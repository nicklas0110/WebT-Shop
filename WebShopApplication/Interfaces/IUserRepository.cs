using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IUserRepository
{
    public User GetUserByEmail(string email);
    public User CreateNewUser(User user);
    void RebuildDB();
}