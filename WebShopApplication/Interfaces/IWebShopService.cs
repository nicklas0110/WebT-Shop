using WebShopApplication.DTOs;
using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopService
{
    List<ItemDTO> GetAllItems();
    Item CreateNewItem(ItemDTO dto);
    Item GetItemById(int id);
    void RebuildDB();
    void SeedData();
    ItemDTO UpdateItem(int id, ItemDTO item);
    object? DeleteUpdateItem(int id);
    

    Category CreateNewCategory(ItemCategoryDTO dto);
    List<Category> GetAllCategories();
    Category UpdateCategory(int id, Category category);
    Category DeleteCategory(int id, CategorySingleEditModel category);

    Option CreateNewOption(OptionDTOs optionDto);
    List<Option> GetAllOptions();
    Option UpdateOption(int id, Option option);
    Option DeleteOption(int id,OptionSingleEditModel option);
    
    OptionGroup CreateNewOptionGroup(OptionGroupDTOs optionGroupDto);
    List<OptionGroup> GetAllOptionGroups();
    OptionGroup UpdateOptionGroups(int id, OptionGroup option);
    
}