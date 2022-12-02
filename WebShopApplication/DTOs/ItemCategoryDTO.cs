using WebsShopDomain;

namespace WebShopApplication.DTOs;

public class ItemCategoryDTO
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    
    public DateTime? DeletedAt { get; set; }
    
    public List<Item> Items { get; set; }
    
    public ItemCategoryDTO(){}

    public ItemCategoryDTO(ItemCategoryPostModel postModel)
    {
        CategoryName = postModel.Name;
    }
    
    public ItemCategoryDTO(CategorySingleEditModel postModel)
    {
        Id = postModel.Id;
        DeletedAt = postModel.DeletedAt;
    }
}

public class ItemCategoryPostModel
{
    public string Name { get; set; }
}

public class CategorySingleEditModel
{
    public int Id { get; set; }
    public DateTime DeletedAt { get; set; }
}