using AutoMapper;
using FluentValidation;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopApplication;

public class WebShopService : IWebShopService {
    
    private IWebShopItemRepository Repository;
    
    private readonly IWebShopItemRepository _itemRepository;
    private readonly IWebShopCategoryRepository _categoryRepository;
    private readonly IWebShopOptionRepository _optionRepository;
    private readonly IValidator<WebShopDTOs> _postValidator;
    private readonly IValidator<Item> _itemValidator;
    private readonly IValidator<WebShopDTOsCategory> _postValidatorCategory;
    private readonly IValidator<Category> _categoryValidator;
    private readonly IValidator<OptionDTOs> _postValidatorOption;
    private readonly IValidator<Option> _optionValidator;
    private readonly IMapper _mapper;
    
    public WebShopService(IWebShopItemRepository repository)
    {
        if (repository == null)
        {
            throw new ArgumentException("Missing repository");
        }
        Repository = repository;
    }

    public List<Item> GetAllItems()
    {
        return _itemRepository.GetAllItems();
    }

    public Item CreateNewItem(WebShopDTOs dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return _itemRepository.CreateNewItem(_mapper.Map<Item>(dto));
    }

    public Item GetItemById(int id)
    {
        throw new NotImplementedException();
    }

    public void RebuildDB()
    {
        _itemRepository.RebuildDB();
    }

    public Item UpdateItem(int id, Item product)
    {
        throw new NotImplementedException();
    }

    public Item DeleteItem(int id)
    {
        throw new NotImplementedException();
    }

    public Category CreateNewCategory(WebShopDTOsCategory dtoCategory)
    {
        var validation = _postValidatorCategory.Validate(dtoCategory);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return _categoryRepository.CreateNewCategory(_mapper.Map<Category>(dtoCategory));
    }

    public List<Category> GetAllCategories()
    {
        return _categoryRepository.GetAllCategories();
    }

    public Option CreateNewOption(OptionDTOs optionDto)
    {
        var validation = _postValidatorOption.Validate(optionDto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return _optionRepository.CreateNewOption(_mapper.Map<Option>(optionDto));
    }

    public List<Option> GetAllOptions()
    {
        return _optionRepository.GetAllOptions();
    }
}