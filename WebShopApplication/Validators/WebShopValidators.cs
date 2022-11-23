using FluentValidation;
using WebShopApplication.DTOs;
using WebsShopDomain;

namespace WebShopApplication.Validators;

public class PostBoxValidator : AbstractValidator<WebShopDTOs>
{
    public PostBoxValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Price).NotEmpty();
        RuleFor(p => p.ItemCategoryId).NotEmpty();
        RuleFor(p => p.ItemCategory).NotEmpty();
        RuleFor(p => p.Options).NotEmpty();
    }
}
public class WebShopValidators : AbstractValidator<Item>
{
    public WebShopValidators()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Price).NotEmpty();
        RuleFor(p => p.ItemCategoryId).NotEmpty();
        RuleFor(p => p.ItemCategory).NotEmpty();
        RuleFor(p => p.Options).NotEmpty();
        RuleFor(p => p.Id).GreaterThan(0);
    }
}

public class PostBoxValidatorCategory : AbstractValidator<WebShopDTOsCategory>
{
    public PostBoxValidatorCategory()
    {
        RuleFor(p => p.CategoryName).NotEmpty();
    }
}
public class WebShopValidatorsCategory : AbstractValidator<Category>
{
    public WebShopValidatorsCategory()
    {
        RuleFor(p => p.CategoryName).NotEmpty();
    }
}