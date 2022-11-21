namespace WebsShopDomain;

public class Category : BaseClass
{
    public string CategoryName { get; set; }
    public List<Item> Items { get; set; }
}