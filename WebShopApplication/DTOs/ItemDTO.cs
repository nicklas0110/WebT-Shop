using WebsShopDomain;

namespace WebShopApplication.DTOs;

public class ItemDTO
{
    public ItemDTO(DateTime deletedAt)
    {
        this.DeletedAt = DateTime.UtcNow;;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public DateTime DeletedAt { get; set; }
    
    public int ItemCategoryId { get; set; }
    
    public Category ItemCategory { get; set; }
    
    public List<Option> Options { get; set; }

    public List<int> OptionIds { get; set; }
    public ItemDTO() {}
    
    public ItemDTO(ItemPostModel postModel)
    {
        Name = postModel.Name;
        Price = postModel.Price;
        ItemCategoryId = postModel.ItemCategoryId;
        OptionIds = postModel.OptionIds;
    }
    
    public ItemDTO(ItemSingleEditModel itemSingleEditModel)
    {
        Id = itemSingleEditModel.Id;
        DeletedAt = itemSingleEditModel.DeletedAt;
    }
    
    
}

public class ItemPostModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int ItemCategoryId { get; set; }
    public List<int> OptionIds { get; set; }
}

public class ItemSingleEditModel
{
    public int Id { get; set; }
    public DateTime DeletedAt { get; set; }
}