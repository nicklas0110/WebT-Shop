using AutoMapper;
using FluentValidation;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebShopApplication.Validators;
using WebsShopDomain;

namespace WebShopApplication;

public class WebShopService : IWebShopService {
    
    private IWebShopItemRepository Repository;
    
    private readonly IWebShopItemRepository _itemRepository;
    private readonly IWebShopCategoryRepository _categoryRepository;
    private readonly IWebShopOptionRepository _optionRepository;
    private readonly PostBoxValidator _postValidator;
    private readonly ItemValidator _itemValidator;
    private readonly CategoryValidator _postValidatorCategory;
    private readonly IValidator<Category> _categoryValidator;
    private readonly PostOptionValidatorOption _postValidatorOption;
    private readonly IValidator<Option> _optionValidator;
    private readonly IMapper _mapper;
    
    public WebShopService(
        IWebShopItemRepository itemRepository,
        IWebShopCategoryRepository categoryRepository,
        IWebShopOptionRepository optionRepository,
        PostBoxValidator postValidatorWebShopDTOs,
        ItemValidator itemValidator,
        CategoryValidator postValidatorCategory,
        IValidator<Category> categoryValidator,
        PostOptionValidatorOption postValidatorOption,
        IValidator<Option> optionValidator,
        IMapper mapper
        
    )
    {
        _itemRepository = itemRepository;
        _categoryRepository = categoryRepository;
        _optionRepository = optionRepository;
        _postValidator = postValidatorWebShopDTOs;
        _itemValidator = itemValidator;
        _postValidatorCategory = postValidatorCategory;
        _categoryValidator = categoryValidator;
        _postValidatorOption = postValidatorOption;
        _optionValidator = optionValidator;
        _mapper = mapper;

    }

    public List<Item> GetAllItems()
    {
        return _itemRepository.GetAllItems();
    }

    public Item CreateNewItem(ItemDTO dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        var item = new Item(dto.Name,dto.Price);
        return _itemRepository.CreateNewItem(item);
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

    public Category CreateNewCategory(ItemCategoryDTO dtoCategoryDto)
    {
        var validation = _postValidatorCategory.Validate(dtoCategoryDto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        var category = new Category(dtoCategoryDto.CategoryName);
        return _categoryRepository.CreateNewCategory(category);
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
        var option = new Option(optionDto.Name);
        return _optionRepository.CreateNewOption(option);
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