using WebsShopDomain;

namespace WebShopApplication.DTOs;

public class OptionGroupDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public List<OptionDTO> Options { get; set; }
    public OptionGroupDTO()
    {
    }

    public OptionGroupDTO(OptionGroupPostModel postModel)
    {
        Name = postModel.Name;
        
    }

    public OptionGroupDTO(OptionGroupSingleEditModel postModel)
    {
        Id = postModel.Id;
    }

    public OptionGroupDTO(OptionGroup model)
    {
        Id = model.Id;
        Name = model.Name;
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        DeletedAt = model.DeletedAt;
    }
}

public class OptionGroupPostModel
{
    public string Name { get; set; }
    
} 

public class OptionGroupSingleEditModel
{
    public int Id { get; set; }
    public DateTime DeletedAt { get; set; }
    
}
