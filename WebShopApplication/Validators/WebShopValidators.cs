using FluentValidation;
using WebShopApplication.DTOs;
using WebsShopDomain;

namespace WebShopApplication.Validators;

public class PostBoxValidator : AbstractValidator<WebShopDTOs>
{
    public PostBoxValidator()
    {
        RuleFor(p => p.Size).NotEmpty();
        RuleFor(p => p.Type).NotEmpty();
        RuleFor(p => p.Color).NotEmpty();
    }
}
public class WebShopValidators : AbstractValidator<TShirt>
{
    public WebShopValidators()
    {
        RuleFor(p => p.size).NotEmpty();
        RuleFor(p => p.type).NotEmpty();
        RuleFor(p => p.color).NotEmpty();
        RuleFor(p => p.Id).GreaterThan(0);
    }
}