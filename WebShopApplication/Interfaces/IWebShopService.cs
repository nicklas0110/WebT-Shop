using WebShopApplication.DTOs;
using WebsShopDomain;

namespace WebShopApplication.Interfaces;

public interface IWebShopService
{
    List<ItemDTO> GetAllItems();
    List<ItemDTO> GetAllItemWithFilter(int? categoryId, List<List<int>> optionIds);
    ItemDTO CreateNewItem(ItemDTO dto);
    Item GetItemById(int id);
    void RebuildDB();
    void SeedData();
    ItemDTO UpdateItem(int id, ItemDTO item);
    object? DeleteUpdateItem(int id);
    

    Category CreateNewCategory(ItemCategoryDTO dto);
    List<Category> GetAllCategories();
    Category UpdateCategory(int id, Category category);
    Category DeleteCategory(int id);

    Option CreateNewOption(OptionDTO optionDto);
    List<Option> GetAllOptions();
    Option UpdateOption(int id, Option option);
    List<Option> GetOptionByGroupId(int id);
    Option DeleteOption(int id);
    

    OptionGroup CreateNewOptionGroup(OptionGroupDTO optionGroupDto);
    List<OptionGroup> GetAllOptionGroups();
    OptionGroup UpdateOptionGroups(int id, OptionGroup option);
    OptionGroup DeleteOptionGroups(int id);
    List<OptionGroupDTO> GetAllOptionGroupsWithOptions();
}