using System.ComponentModel.DataAnnotations.Schema;

namespace WebsShopDomain;

public class Item : BaseClass
{
    

    public string Name { get; set; }
    public decimal Price { get; set; }
    [ForeignKey("ItemCategory")]
    public int ItemCategoryId { get; set; }
    public Category ItemCategory { get; set; }
    public List<int> OptionIds { get; set; }
    
    public Item(){}

    public Item(DateTime deletedAt)
    {
        DeletedAt = deletedAt;
    }
    public Item(string dtoName, decimal dtoPrice, int itemCategoryId)
    {
        Name = dtoName;
        Price = dtoPrice;
        ItemCategoryId = itemCategoryId;
    }
    public Item(int id, string name, decimal price, int itemCategoryId)
    {
        Id = id;
        Name = name;
        Price = price;
        ItemCategoryId = itemCategoryId;
    }
        
    public Item(int id, string name, decimal price, int itemCategoryId, List<int> optionIds)
    {
        Id = id;
        Name = name;
        Price = price;
        ItemCategoryId = itemCategoryId;
        OptionIds = optionIds;
    }
}