using AutoMapper;
using FluentValidation;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebShopApplication.Validators;
using WebsShopDomain;

namespace WebShopApplication;

public class WebShopService : IWebShopService {
    
    
    
    private IWebShopItemRepository Repository;

    private readonly IWebShopServiceRepository _serviceRepository;

    private readonly ItemDtoValidator _itemDtoValidator;
    private readonly ItemValidator _itemValidator;
    private readonly IWebShopItemRepository _itemRepository;
    
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
    private readonly IValidator<OptionGroup> _optionGroupValidator;
    private readonly PostOptionGroupValidatorOption _postOptionGroupValidator;
    
    private readonly IMapper _mapper;
    
    public WebShopService(
        IWebShopServiceRepository serviceRepository,
        
        IWebShopItemRepository itemRepository,
        ItemDtoValidator itemDtoValidator,
        ItemValidator itemValidator,
        
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
        IValidator<OptionGroup> optionGroupValidator,
        PostOptionGroupValidatorOption postOptionGroupValidator,
        
        IMapper mapper
        
    )
    {
        _serviceRepository = serviceRepository;
        
        _itemRepository = itemRepository;
        _itemDtoValidator = itemDtoValidator;
        _itemValidator = itemValidator;
        
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
        _optionGroupValidator = optionGroupValidator;
        _postOptionGroupValidator = postOptionGroupValidator;

        _mapper = mapper;

    }

    public WebShopService(IWebShopItemRepository itemRepository)
    {
        itemRepository = Repository;
    }

    public List<ItemDTO> GetAllItems()
    {
        var items = _itemRepository.GetAllItems();
        var itemOptions = _itemOptionRepositoryRepo.GetByItemIds(items.Select(i => i.Id).ToList());
        var itemDtos = new List<ItemDTO>();
        foreach (var item in items)
        {
            var optionIds = itemOptions.Where(io => io.ItemId == item.Id).Select(io  => io.OptionId).ToList();
            itemDtos.Add(new ItemDTO(item, optionIds));
        }
        return itemDtos;
    }

    public ItemDTO CreateNewItem(ItemDTO dto)
    {
        var validation = _itemDtoValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        var item = new Item(dto.Name,dto.Price, dto.ItemCategoryId);
        item = _itemRepository.CreateNewItem(item);
        if (dto.OptionIds.Any())
        {
            AddOptionToItem(dto.OptionIds, item.Id);
        }
        return new ItemDTO(item, dto.OptionIds);
    }

    private void AddOptionToItem(List<int> optionIds, int itemId)
    {
        // to do create ItemOptions
        var itemOptions = new List<ItemOption>();
        foreach (var optionId in optionIds)
        {
            itemOptions.Add(new ItemOption() { ItemId = itemId, OptionId = optionId });
        }
        _itemOptionRepositoryRepo.CreateItemOptions(itemOptions);
    }

    public Item GetItemById(int id)
    {
        throw new NotImplementedException();
    }

    public void RebuildDB()
    {
        _serviceRepository.RebuildDB();
        SeedData();
    }

    public void SeedData()
    {
        // create option groups
        var optionGroups = new List<OptionGroup>()
        {
            new OptionGroup("Color"),
            new OptionGroup("Size"),
            new OptionGroup("Print"),
            new OptionGroup("Material")
        };
        foreach (var optionGroup in optionGroups)
        {
            _optionGroupRepository.CreateNewOptionGroup(optionGroup);
        }
        // create option
        var options = new List<Option>()
        {
            new Option("Rød", 1),
            new Option("Blå", 1),
            new Option("Hvid", 1),
            new Option("Sort", 1),
            new Option("S", 2),
            new Option("M", 2),
            new Option("L", 2),
            new Option("XL", 2),
            new Option("XXL", 2),
            new Option("Ja", 3),
            new Option("Nej", 3)
        };
        foreach (var option in options)
        {
            _optionRepository.CreateNewOption(option);
        }
        // create category
        var categories = new List<Category>()
        {
            new Category("T-Shit")
        };
        foreach (var category in categories)
        {
            _categoryRepository.CreateNewCategory(category);
        }
    }


    public ItemDTO UpdateItem(int id, ItemDTO itemDto)
    {
        if (id != itemDto.Id)
            throw new ValidationException("ID in body and route are different");
        var validation = _itemDtoValidator.Validate(itemDto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        var item = new Item(itemDto.Id, itemDto.Name, itemDto.Price, itemDto.ItemCategoryId);
        var itemIds = new List<int>();
        itemIds.Add(item.Id);
        var io = _itemOptionRepositoryRepo.GetByItemIds(itemIds);
        var ioToDelete = io.Where(io => !itemDto.OptionIds.Contains(io.OptionId)).Select(io => io.Id);
        foreach (var ioId in ioToDelete)
        {
            _itemOptionRepositoryRepo.DeleteItemOption(ioId);

        }
        AddOptionToItem(itemDto.OptionIds.Where(o => !io.Exists(x => x.OptionId == o)).ToList(), item.Id);
        var updatedItem = _itemRepository.UpdateItem(id, item);
        return new ItemDTO(updatedItem, itemDto.OptionIds);
    }
    
    public object? DeleteUpdateItem(int id)
    {
        return _itemRepository.DeleteUpdateItem(id);
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
        return _categoryRepository.DeleteCategory(id);
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
        return _optionRepository.UpdateOption(option);
    }

    public Option DeleteOption(int id)
    {
        return _optionRepository.DeleteOption(id);
    }

    public OptionGroup CreateNewOptionGroup(OptionGroupDTOs optionGroupDto)
    {
        var validation = _postOptionGroupValidator.Validate(optionGroupDto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        var optionGroup = new OptionGroup(optionGroupDto.Name);
        return _optionGroupRepository.CreateNewOptionGroup(optionGroup);
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
}