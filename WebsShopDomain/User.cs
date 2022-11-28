namespace WebsShopDomain;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Hash { get; set; }
    public string salt { get; set; }
}