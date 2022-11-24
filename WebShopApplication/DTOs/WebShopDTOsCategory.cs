﻿using WebsShopDomain;

namespace WebShopApplication.DTOs;

public class WebShopDTOsCategory
{
    public string CategoryName { get; set; }
    
    public List<Category> CategoryItems { get; set; }
}