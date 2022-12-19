using System.Collections;
using WebsShopDomain;

namespace WebShopApplication.DTOs;

public class ItemCategoryDTO
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    
    public DateTime? DeletedAt { get; set; }
    
    public List<Item> Items { get; set; }
    
    public ItemCategoryDTO(){}

    public ItemCategoryDTO(ItemCategoryPostModel postModel)
    {
        CategoryName = postModel.CategoryName;
    }
    
    public ItemCategoryDTO(CategorySingleEditModel postModel)
    {
        Id = postModel.Id;
        DeletedAt = postModel.DeletedAt;
    }

    public ItemCategoryDTO(Category model)
    {
        Id = model.Id;
        CategoryName = model.CategoryName;
        CreatedAt = model.CreatedAt;
        UpdatedAt = model.UpdatedAt;
        DeletedAt = model.DeletedAt;
    }
    
    public ItemCategoryDTO(CategoryEditModel editModel)
    {
        Id = editModel.Id;
        CategoryName = editModel.CategoryName;
        Items = editModel.Items;
    }

    public ItemCategoryDTO(ItemCategoryDTO model)
    {
        Id = model.Id;
        CategoryName = model.CategoryName;
    }
}

public class ItemCategoryPostModel
{
    public string CategoryName { get; set; }
}

public class CategorySingleEditModel
{
    public int Id { get; set; }
    public DateTime DeletedAt { get; set; }
}

public class CategoryGetAllDto : IEnumerable<object>
{
    public int Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime DeletedAt { get; set; }
    public IEnumerator<object> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class  CategoryEditModel
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public List<Item> Items { get; set; }
}