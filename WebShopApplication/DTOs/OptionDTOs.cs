﻿using WebsShopDomain;

namespace WebShopApplication.DTOs;

public class OptionDTOs
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public OptionGroup Group { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    
    public DateTime? DeletedAt { get; set; }
    
    public List<Item> Items { get; set; }
    
    public OptionDTOs(){}
    
    public OptionDTOs(ItemOptionPostModel postModel)
    {
        Name = postModel.Name;
    }
    
    public OptionDTOs(OptionSingleEditModel postModel)
    {
        Id = postModel.Id;
        DeletedAt = postModel.DeletedAt;
    }
}


public class ItemOptionPostModel
{
    public string Name { get; set; }
    
} 

public class OptionSingleEditModel
{
    public int Id { get; set; }
    public DateTime DeletedAt { get; set; }
    
}