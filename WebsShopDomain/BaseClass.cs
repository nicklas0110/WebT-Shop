namespace WebsShopDomain;

public class BaseClass
{
    public BaseClass()
    {
        this.CreatedAt = DateTime.UtcNow;
    }
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public DateTime? DeletedAt { get; set; }
}