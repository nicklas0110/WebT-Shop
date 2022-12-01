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