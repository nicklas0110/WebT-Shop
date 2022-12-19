namespace WebsShopDomain;

public class Category : BaseClass
{
    public string CategoryName { get; set; }

    public Category(){}
    public Category(int categoryDtoId, string categoryName)
    {
        CategoryName = categoryName;
    }

    public Category(string dtoCategoryName)
    {
        CategoryName = dtoCategoryName;
    }
}