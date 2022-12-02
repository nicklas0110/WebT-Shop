﻿using WebShopApplication.DTOs;
using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopService
{
    List<Item> GetAllItems();
    Item CreateNewItem(ItemDTO dto);
    Item GetItemById(int id);
    void RebuildDB();
    Item UpdateItem(int id, Item product);
    object? DeleteUpdateItem(int id, ItemSingleEditModel item);
    

    Category CreateNewCategory(ItemCategoryDTO dto);
    List<Category> GetAllCategories(CategoryGetAllDto deleteAt, CategoryGetAllDto updatedAt);
    Category UpdateCategory(int id, Category category);
    Category DeleteCategory(int id, CategorySingleEditModel category);

    Option CreateNewOption(OptionDTOs optionDto);
    List<Option> GetAllOptions();
    Option UpdateOption(int id, Option option);
    Option DeleteOption(int id,OptionSingleEditModel option);
    
}