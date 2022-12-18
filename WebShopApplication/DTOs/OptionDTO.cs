using WebsShopDomain;

namespace WebShopApplication.DTOs;

public class OptionDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public OptionGroup Group { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    
    public DateTime? DeletedAt { get; set; }
    
    public List<Item> Items { get; set; }
    public int OptionGroupId { get; set; }

    
    public OptionDTO(){}
    
    public OptionDTO(ItemOptionPostModel postModel)
    {
        Name = postModel.Name;
        OptionGroupId = postModel.OptionGroupId;
    }
    
    public OptionDTO(Option model)
    {
        Id = model.Id;
        Name = model.Name;
        OptionGroupId = model.OptionGroupId;
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        DeletedAt = model.DeletedAt;
    }
    
    public OptionDTO(OptionSingleEditModel postModel)
    {
        Id = postModel.Id;
    }
}


public class ItemOptionPostModel
{
    public string Name { get; set; }
    public int OptionGroupId { get; set; }
    
} 

public class OptionSingleEditModel
{
    public int Id { get; set; }
    public DateTime DeletedAt { get; set; }
    
}