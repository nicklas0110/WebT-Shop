﻿using WebsShopDomain;

namespace WebShopApplication.DTOs;

public class WebShopDTOs
{
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public int ItemCategoryId { get; set; }
    
    public Category ItemCategory { get; set; }
    
    public List<Option> Options { get; set; }
    
}