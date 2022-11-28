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
        _itemRepository = repository;
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
        if (id != product.Id)
            throw new ValidationException("ID in body and route are different");
        var validation = _itemValidator.Validate(product);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        return _itemRepository.UpdateItem(id ,product);;
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
        throw new NotImplementedException();
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

    public Option UpdateOption(int id, Option option)
    {
        if (id != option.Id)
            throw new ValidationException("ID in body and route are different");
        var validation = _optionValidator.Validate(option);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        return _optionRepository.UpdateOption(option);;
    }

    public Option DeleteOption(int id)
    {
        throw new NotImplementedException();
    }
}