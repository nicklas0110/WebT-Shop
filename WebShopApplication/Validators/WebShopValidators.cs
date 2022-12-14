using FluentValidation;
using WebShopApplication.DTOs;
using WebsShopDomain;

namespace WebShopApplication.Validators;

public class ItemDtoValidator : AbstractValidator<ItemDTO>
{
    public ItemDtoValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Price).NotEmpty();
        RuleFor(i => i.ItemCategoryId).NotEmpty();
        //RuleFor(p => p.ItemCategoryId).NotEmpty();
    }
}


public class ItemValidator : AbstractValidator<Item>
{
    public ItemValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Price).NotEmpty();
        //RuleFor(p => p.ItemCategoryId).NotEmpty();
        //RuleFor(p => p.Options).NotEmpty(); 
    }
}

public class CategoryValidator : AbstractValidator<ItemCategoryDTO>
{
    public CategoryValidator()
    {
        RuleFor(p => p.CategoryName).NotEmpty();
    }
}
public class CategoryDeleteValidators : AbstractValidator<CategorySingleEditModel>
{
    public CategoryDeleteValidators()
    {
        RuleFor(p => p.DeletedAt).NotEmpty();
    }
}

public class CategoryValidators : AbstractValidator<Category>
{
    public CategoryValidators()
    {
        RuleFor(p => p.CategoryName).NotEmpty();
    }
}

public class PostOptionValidatorOption : AbstractValidator<OptionDTOs>
{
    public PostOptionValidatorOption()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}
public class WebShopValidatorsOption : AbstractValidator<Option>
{
    public WebShopValidatorsOption()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
    
    
}
public class OptionDeleteValidators : AbstractValidator<OptionSingleEditModel>
{
    public OptionDeleteValidators()
    {
        RuleFor(p => p.DeletedAt).NotEmpty();
    }
}
public class WebShopValidatorsOptionGroup : AbstractValidator<OptionGroup>
{
    public WebShopValidatorsOptionGroup()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
    
    
}
public class PostOptionGroupValidatorOption : AbstractValidator<OptionGroupDTOs>
{
    public PostOptionGroupValidatorOption()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}