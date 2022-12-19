using System.Security.Cryptography;

namespace WebsShopDomain;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Hash { get; set; }
    public string Salt { get; set; }
    public string Role { get; set; }
    public int Balance { get; set; }
    
    
    public User(){}
    
    

    public User(int id, string email, string hash, string salt, string role, int balance)
    {
        Id = id;
        Email = email;
        Hash = hash;
        Salt = salt;
        Role = role;
        Balance = balance;
    }
}

