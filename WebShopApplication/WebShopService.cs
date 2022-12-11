using AutoMapper;
using FluentValidation;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebShopApplication.Validators;
using WebsShopDomain;

namespace WebShopApplication;

public class WebShopService : IWebShopService {
    
    private IWebShopItemRepository Repository;
    
    private readonly PostBoxValidator _postValidator;
    private readonly ItemValidator _itemValidator;
    private readonly IWebShopItemRepository _itemRepository;
    private readonly PostDeleteValidator _itemSingleEditRepositoryPost;
    
    private readonly IWebShopCategoryRepository _categoryRepository;
    private readonly CategoryValidator _postValidatorCategory;
    private readonly IValidator<Category> _categoryValidator;
    private readonly CategoryDeleteValidators _categoryDeleteValidators;
    
    private readonly IWebShopOptionRepository _optionRepository;
    private readonly PostOptionValidatorOption _postValidatorOption;
    private readonly IValidator<Option> _optionValidator;
    private readonly OptionDeleteValidators _optionDeleteValidators;

    private readonly IItemOptionRepository _itemOptionRepositoryRepo;

    private readonly IWebShopOptionGroupRepository _optionGroupRepository;
    private readonly PostOptionGroupValidatorOption _postOptionGroupValidator;
    
    private readonly IMapper _mapper;
    
    public WebShopService(
        IWebShopItemRepository itemRepository,
        PostBoxValidator postValidatorWebShopDTOs,
        ItemValidator itemValidator,
        PostDeleteValidator itemSingleEditRepositoryPost,
        
        IWebShopCategoryRepository categoryRepository,
        CategoryValidator postValidatorCategory,
        IValidator<Category> categoryValidator,
        CategoryDeleteValidators categoryDeleteValidators,
        
        IWebShopOptionRepository optionRepository,
        PostOptionValidatorOption postValidatorOption,
        IValidator<Option> optionValidator,
        OptionDeleteValidators optionDeleteValidators,
        
        IItemOptionRepository itemOptionRepositoryRepo,
        
        IWebShopOptionGroupRepository optionGroupRepository,
        PostOptionGroupValidatorOption postOptionGroupValidator,
        
        IMapper mapper
        
    )
    {
        _itemRepository = itemRepository;
        _postValidator = postValidatorWebShopDTOs;
        _itemValidator = itemValidator;
        _itemSingleEditRepositoryPost = itemSingleEditRepositoryPost;
        
        _categoryRepository = categoryRepository;
        _postValidatorCategory = postValidatorCategory;
        _categoryValidator = categoryValidator;
        _categoryDeleteValidators = categoryDeleteValidators;
        
        _optionRepository = optionRepository;
        _postValidatorOption = postValidatorOption;
        _optionValidator = optionValidator;
        _optionDeleteValidators = optionDeleteValidators;

        _itemOptionRepositoryRepo = itemOptionRepositoryRepo;

        _optionGroupRepository = optionGroupRepository;
        _postOptionGroupValidator = postOptionGroupValidator;

        _mapper = mapper;

    }

    public WebShopService(IWebShopItemRepository itemRepository)
    {
        itemRepository = Repository;
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
        var item = new Item(dto.Name,dto.Price, dto.ItemCategoryId);
        item = _itemRepository.CreateNewItem(item);
        if (dto.OptionIds.Any())
        {
            // to do create ItemOptions
            var itemOptions = new List<ItemOption>();
            foreach (var optionId in dto.OptionIds)
            {
                itemOptions.Add(new ItemOption() { ItemId = item.Id, OptionId = optionId });
            }
            _itemOptionRepositoryRepo.CreateItemOptions(itemOptions);
        }
        return item;
    }

    public Item GetItemById(int id)
    {
        throw new NotImplementedException();
    }

    public void RebuildDB()
    {
        _itemRepository.RebuildDB();
        _categoryRepository.RebuildDB();
        _optionRepository.RebuildDB();
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
    
    public object? DeleteUpdateItem(int id, ItemSingleEditModel dto)
    {
        if (id != dto.Id)
            throw new ValidationException("ID in body and route are different");
        var validation = _itemSingleEditRepositoryPost.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        var item = new ItemSingleEditModel{DeletedAt = DateTime.Now};
        return _itemRepository.DeleteUpdateItem(id ,item);;
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

    public Category DeleteCategory(int id, CategorySingleEditModel dto)
    {
        if (id != dto.Id)
            throw new ValidationException("ID in body and route are different");
        var validation = _categoryDeleteValidators.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        var category = new CategorySingleEditModel{DeletedAt = DateTime.Now};
        return _categoryRepository.DeleteCategory(id ,category);;
    }

    
    public Option CreateNewOption(OptionDTOs optionDto)
    {
        var validation = _postValidatorOption.Validate(optionDto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        var option = new Option(optionDto.Name, optionDto.OptionGroupId);
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

    public Option DeleteOption(int id,OptionSingleEditModel dto)
    {
        if (id != dto.Id)
            throw new ValidationException("ID in body and route are different");
        var validation = _optionDeleteValidators.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        var option = new OptionSingleEditModel{DeletedAt = DateTime.Now};
        return _optionRepository.DeleteOption(id ,option);;
    }

    public OptionGroup CreateNewOptionGroup(OptionGroupDTOs optionDto)
    {
        var validation = _postOptionGroupValidator.Validate(optionDto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        var optionGroup = new OptionGroup(optionDto.Name);
        return _optionGroupRepository.CreateNewOptionGroup(optionGroup);
    }


    public List<OptionGroup> GetAllOptionGroups()
    {
        return _optionGroupRepository.GetAllOptionGroups();
    }
}