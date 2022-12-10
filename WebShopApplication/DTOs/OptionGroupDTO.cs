namespace WebShopApplication.DTOs;

public class OptionGroupDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    
    public DateTime? DeletedAt { get; set; }


    public OptionGroupDTO(){}
    
    public OptionGroupDTO(OptionGroupsPostModel postModel)
    {
        Name = postModel.Name;
    }
    
    public OptionGroupDTO(OptionSingleEditModel postModel)
    {
        Id = postModel.Id;
    }
}


public class OptionGroupsPostModel
{
    public string Name { get; set; }
} 

public class OptionGroupDTOSingleEditModel
{
    public int Id { get; set; }
    
    public DateTime DeletedAt { get; set; }
    
}
