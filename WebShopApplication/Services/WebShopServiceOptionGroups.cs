using FluentValidation;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebShopApplication.Validators;
using WebsShopDomain;

namespace WebShopApplication;

public class WebShopServiceOptionGroups : IWebShopServiceOptionGroups
{
    private readonly IWebShopOptionGroupRepository _optionGroupRepository;
    private readonly IValidator<OptionGroup> _optionGroupValidator;
    private readonly PostOptionGroupValidatorOption _postOptionGroupValidator;
    private readonly IWebShopServiceOption _webShopServiceOption;

    public WebShopServiceOptionGroups(
        IWebShopOptionGroupRepository optionGroupRepository,
        IValidator<OptionGroup> optionGroupValidator,
        PostOptionGroupValidatorOption postOptionGroupValidator,
        IWebShopServiceOption webShopServiceOption
    )
    {
        _optionGroupRepository = optionGroupRepository;
        _optionGroupValidator = optionGroupValidator;
        _postOptionGroupValidator = postOptionGroupValidator;
        _webShopServiceOption = webShopServiceOption;
    }

    public OptionGroupDTO CreateNewOptionGroup(OptionGroupDTO optionGroupDto)
    {
        var validation = _postOptionGroupValidator.Validate(optionGroupDto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        var optionGroup = new OptionGroup(optionGroupDto.Name);
        optionGroup = _optionGroupRepository.CreateNewOptionGroup(optionGroup);
        return new OptionGroupDTO(optionGroup);
    }


    public List<OptionGroup> GetAllOptionGroups()
    {
        return _optionGroupRepository.GetAllOptionGroups();
    }

    public OptionGroup UpdateOptionGroups(int id, OptionGroup optionGroup)
    {
        if (id != optionGroup.Id)
            throw new ValidationException("ID in body and route are different");
        var validation = _optionGroupValidator.Validate(optionGroup);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        return _optionGroupRepository.UpdateOptionGroups(optionGroup);
    }

    public OptionGroup DeleteOptionGroups(int id)
    {
        return _optionGroupRepository.DeleteOptionGroups(id);
    }

    public List<OptionGroupDTO> GetAllOptionGroupsWithOptions()
    {
        var optionGroups = GetAllOptionGroups();
        var options = _webShopServiceOption.GetAllOptions();

        return GetAllOptionsWithOptionGroupsMapping(optionGroups, options);
    }

    public List<OptionGroupDTO> GetAllOptionsWithOptionGroupsMapping(List<OptionGroup> optionGroups,
        List<Option> options)
    {
        var groupDtos = new List<OptionGroupDTO>();
        foreach (var optionGroup in optionGroups)
        {
            var optionDtos = options.Where(o => o.OptionGroupId == optionGroup.Id).Select(o => new OptionDTO(o)).ToList();
            var optionGroupDtos = new OptionGroupDTO()
                { Id = optionGroup.Id, Name = optionGroup.Name, Options = optionDtos };
            groupDtos.Add(optionGroupDtos);
        }
        return groupDtos.Where(o => o.Options.Any()).ToList();
    }
}