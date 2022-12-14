namespace WebsShopDomain;

public class Category : BaseClass
{
    public string CategoryName { get; set; }

    public Category(){}
    public Category(string categoryName)
    {
        CategoryName = categoryName;
    }
}