namespace WebShopApplication.DTOs;

public class OptionGroupDTOs
{
    public int Id { get; set; }
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }


    public OptionGroupDTOs()
    {
    }

    public OptionGroupDTOs(OptionGroupPostModel postModel)
    {
        Name = postModel.Name;
        
    }

    public OptionGroupDTOs(OptionGroupSingleEditModel postModel)
    {
        Id = postModel.Id;
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
