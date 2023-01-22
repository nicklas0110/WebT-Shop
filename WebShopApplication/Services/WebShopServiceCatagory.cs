using FluentValidation;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebShopApplication.Validators;
using WebsShopDomain;

namespace WebShopApplication;

public class WebShopServiceCategory : IWebShopServiceCategory
{
    private readonly IWebShopCategoryRepository _categoryRepository;
    private readonly CategoryValidator _postValidatorCategory;
    private readonly IValidator<Category> _categoryValidator;
    private readonly CategoryDeleteValidators _categoryDeleteValidators;
    
    public WebShopServiceCategory( 
        IWebShopCategoryRepository categoryRepository,
        CategoryValidator postValidatorCategory,
        IValidator<Category> categoryValidator,
        CategoryDeleteValidators categoryDeleteValidators
        )
    {
        _categoryRepository = categoryRepository;
        _postValidatorCategory = postValidatorCategory;
        _categoryValidator = categoryValidator;
        _categoryDeleteValidators = categoryDeleteValidators;
    }


    public ItemCategoryDTO CreateNewCategory(ItemCategoryDTO dto)
    {
        var validation = _postValidatorCategory.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        var category = new Category(dto.CategoryName);
        category = _categoryRepository.CreateNewCategory(category);
        return new ItemCategoryDTO(category);
    }

    public List<ItemCategoryDTO> GetAllCategories()
    {
        var catagorys = _categoryRepository.GetAllCategories();
        var catagoryDtos = new List<ItemCategoryDTO>();
        foreach (var catagory in catagorys)
        {
            catagoryDtos.Add(new ItemCategoryDTO(catagory));
        }
        return catagoryDtos;
    }

    public Category UpdateCategory(int id, Category category)
    {
        if (id != category.Id)
            throw new ValidationException("ID in body and route are different");
        var validation = _categoryValidator.Validate(category);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        return _categoryRepository.UpdateCategory(category);
    }

    public Category DeleteCategory(int id)
    {
        return _categoryRepository.DeleteCategory(id);
    }
}