﻿using System.Text.Json.Serialization;
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
    
    public ItemDTO(Item model, List<int> optionIds)
    {
        Id = model.Id;
        Name = model.Name;
        Price = model.Price;
        ItemCategoryId = model.ItemCategoryId;
        OptionIds = optionIds;
    }
    
    public ItemDTO(ItemEditModel editModel)
    {
        Id = editModel.Id;
        Name = editModel.Name;
        Price = editModel.Price;
        ItemCategoryId = editModel.ItemCategoryId;
        OptionIds = editModel.OptionIds;
    }
    
    
}

public class ItemPostModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int ItemCategoryId { get; set; }
    public List<int> OptionIds { get; set; }
}

public class ItemEditModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int ItemCategoryId { get; set; }
    public List<int> OptionIds { get; set; }
}