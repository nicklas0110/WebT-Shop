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

public class TShirt
{
    public int Id { get; set; }
        
    public string size { get; set;}

    public string color { get; set;}
        
    public string type { get; set;}

}

public class Category : BaseClass
{
    public string CategoryName { get; set; }
    public List<Item> Items { get; set; }
}

public class Item : BaseClass
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int ItemCategoryId { get; set; }
    public Category ItemCategory { get; set; }
    public List<Option> Options { get; set; }
}

public class Option : BaseClass
{
    public string Name { get; set; }
    public OptionGroup Group { get; set; }
}

public class OptionGroup : BaseClass
{
    public string Name { get; set; }
}