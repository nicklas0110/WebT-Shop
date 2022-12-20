using System.ComponentModel.DataAnnotations.Schema;

namespace WebsShopDomain;

public class Item : BaseClass
{
    public string Name { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; }
    [ForeignKey("ItemCategory")]
    public int ItemCategoryId { get; set; }
    public Category ItemCategory { get; set; }
    //public List<int> OptionIds { get; set; }
    
    public Item(){}

    public Item(DateTime deletedAt)
    {
        DeletedAt = deletedAt;
    }
    public Item(string dtoName, string dtoImage, decimal dtoPrice, int itemCategoryId)
    {
        Name = dtoName;
        Image = dtoImage;
        Price = dtoPrice;
        ItemCategoryId = itemCategoryId;
    }
    public Item(int id, string name, string dtoImage, decimal price, int itemCategoryId)
    {
        Id = id;
        Name = name;
        Image = dtoImage;
        Price = price;
        ItemCategoryId = itemCategoryId;
    }
}