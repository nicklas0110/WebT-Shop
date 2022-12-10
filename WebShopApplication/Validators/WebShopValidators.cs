using FluentValidation;
using WebShopApplication.DTOs;
using WebsShopDomain;

namespace WebShopApplication.Validators;

public class PostBoxValidator : AbstractValidator<ItemDTO>
{
    public PostBoxValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Price).NotEmpty();
        //RuleFor(p => p.ItemCategoryId).NotEmpty();
    }
}

public class PostDeleteValidator : AbstractValidator<ItemSingleEditModel>
{
    public PostDeleteValidator()
    {
        RuleFor(p => p.DeletedAt).NotEmpty();
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

public class PostOptionValidatorOptionGroup : AbstractValidator<OptionGroupDTO>
{
    public PostOptionValidatorOptionGroup()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}
public class WebShopValidatorsOptionGroup : AbstractValidator<OptionGroup>
{
    public WebShopValidatorsOptionGroup()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
    
    
}
public class OptionGroupDeleteValidators : AbstractValidator<OptionGroupDTOSingleEditModel>
{
    public OptionGroupDeleteValidators()
    {
        RuleFor(p => p.DeletedAt).NotEmpty();
    }
}