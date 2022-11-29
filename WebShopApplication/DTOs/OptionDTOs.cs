using WebsShopDomain;

namespace WebShopApplication.DTOs;

public class OptionDTOs
{
    public int Id { get; set; }
    public string Name { get; set; }
    public OptionGroup Group { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    
    public DateTime? DeletedAt { get; set; }
    
    public OptionDTOs(ItemOptionPostModel postModel)
    {
        Name = postModel.Name;
        Group = postModel.Group;
    }
}





public class ItemOptionPostModel
{
    public string Name { get; set; }
    
    public OptionGroup Group { get; set; }
}