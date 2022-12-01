using WebsShopDomain;

namespace WebShopApplication.DTOs;

public class ItemDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    //public int ItemCategoryId { get; set; }
    
    public Category ItemCategory { get; set; }
    
    //public List<Option> Options { get; set; }

    //public List<int> OptionIds { get; set; }
    public ItemDTO() {}
    
    public ItemDTO(ItemPostModel postModel)
    {
        Name = postModel.Name;
        Price = postModel.Price;
        //ItemCategoryId = postModel.ItemCategoryId;
        //OptionIds = postModel.OptionIds;
    }
}

public class ItemPostModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    //public int ItemCategoryId { get; set; }
    //public List<int> OptionIds { get; set; }
}