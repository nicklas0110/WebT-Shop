using FluentValidation;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebShopApplication.Validators;
using WebsShopDomain;

namespace WebShopApplication;

public class WebShopServiceOption : IWebShopServiceOption
{
    private readonly IWebShopOptionRepository _optionRepository;
    private readonly PostOptionValidatorOption _postValidatorOption;
    private readonly IValidator<Option> _optionValidator;
    private readonly OptionDeleteValidators _optionDeleteValidators;

    public WebShopServiceOption(
        IWebShopOptionRepository optionRepository,
        PostOptionValidatorOption postValidatorOption,
        IValidator<Option> optionValidator,
        OptionDeleteValidators optionDeleteValidators
    )
    {
        _optionRepository = optionRepository;
        _postValidatorOption = postValidatorOption;
        _optionValidator = optionValidator;
        _optionDeleteValidators = optionDeleteValidators;
    }

    public WebShopServiceOption()
    {
        throw new NotImplementedException();
    }

    public OptionDTO CreateNewOption(OptionDTO dto)
    {
        var validation = _postValidatorOption.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        var option = new Option(dto.Name, dto.OptionGroupId);
        option = _optionRepository.CreateNewOption(option);
        return new OptionDTO(option);
    }

    public List<Option> GetAllOptions()
    {
        return _optionRepository.GetAllOptions();
    }

    public Option UpdateOption(int id, Option option)
    {
        if (id != option.Id)
            throw new ValidationException("ID in body and route are different");
        var validation = _optionValidator.Validate(option);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        return _optionRepository.UpdateOption(option);
    }

    public Option DeleteOption(int id)
    {
        return _optionRepository.DeleteOption(id);
    }

    public List<Option> GetOptionByGroupId(int id)
    {
        return _optionRepository.GetOptionByGroupId(id);
    }
}