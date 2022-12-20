using System.Security.Cryptography;
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
    
    private readonly IUserRepository _userRepository;

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
        
        IUserRepository userRepository,
        
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

        _userRepository = userRepository;

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
    
    public List<ItemDTO> GetAllItemWithFilter(int? categoryId, List<List<int>> optionsIds)
    {
        var items = _itemRepository.GetAllItems();
        if (categoryId.HasValue)
        {
            items = items.Where(i => i.ItemCategoryId == categoryId).ToList();
        }
        var itemOptions = _itemOptionRepositoryRepo.GetByItemIds(items.Select(i => i.Id).ToList());
        var itemDtos = new List<ItemDTO>();
        foreach (var item in items)
        {
            var optionIds = itemOptions.Where(io => io.ItemId == item.Id).Select(io  => io.OptionId).ToList();
            var include = true;
            foreach (var optionList in optionsIds)
            {
                if(optionList.Any()) include = optionIds.Intersect(optionList).Any();
                if(!include) break;;
            }
            if(include) itemDtos.Add(new ItemDTO(item, optionIds));
        }
        
        return itemDtos;
    }

    public ItemDTO CreateNewItem(ItemDTO dto)
    {
        var validation = _itemDtoValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        var item = new Item(dto.Name, dto.Image, dto.Price, dto.ItemCategoryId);
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
        
        var salt = RandomNumberGenerator.GetBytes(32).ToString();
        var user1 = new User{Id = 1, Email = "SuperAdmin", Salt = salt, Hash = BCrypt.Net.BCrypt.HashPassword("Password" + salt), Role = "SuperAdmin", Balance = 100 };
        var user2 = new User{Id = 2, Email = "Admin", Salt = salt, Hash = BCrypt.Net.BCrypt.HashPassword("Password" + salt), Role = "Admin", Balance = 100 };
        var user3 = new User{Id = 3, Email = "User", Salt = salt, Hash = BCrypt.Net.BCrypt.HashPassword("Password" + salt), Role = "User", Balance = 0 };
        var user4 = new User{Id = 4, Email = "User2", Salt = salt, Hash = BCrypt.Net.BCrypt.HashPassword("Password" + salt), Role = "User", Balance = 0 };
        _userRepository.CreateNewUser(user1); _userRepository.CreateNewUser(user2); _userRepository.CreateNewUser(user3); _userRepository.CreateNewUser(user4);
        
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
            new Option("Rød", 1), //1
            new Option("Blå", 1), //2
            new Option("Hvid", 1), //3
            new Option("Sort", 1), //4
            new Option("XS", 2), //5
            new Option("S", 2), //6
            new Option("M", 2), //7
            new Option("L", 2), //8
            new Option("XL", 2), //9
            new Option("XXL", 2), //10
            new Option("Print: Im The Boss", 3), //11
            new Option("Print: Not today Satan", 3), //12
            new Option("Print: Im Lucifer Morningstar", 3), //13
            new Option("Polyester", 4), //14
            new Option("Bomuld", 4), //15
            new Option("Uld", 4), //16
            new Option("Kashmir", 4), //17
            new Option("Bambus stof", 4) //18
            
        };
        foreach (var option in options)
        {
            _optionRepository.CreateNewOption(option);
        }
        // create category
        var categories = new List<Category>()
        {
            new Category("T-Shirt"),
            new Category("Sweater")
        };
        foreach (var category in categories)
        {
            _categoryRepository.CreateNewCategory(category);
        }
        // create Item
        // list of Option Ids
        // List<int> list1 = new List<int>() { 1,2,3,5,6,7,8,14,15 };
        // List<int> list2 = new List<int>() { 1,2,3,5,6,7,8,11,14,15 };
        // List<int> list3 = new List<int>() { 1,2,5,6,7,8,12,18 };
        // List<int> list4 = new List<int>() { 1,2,5,6,8,17 };
        // var items = new List<Item>()
        // {
        //     new Item(1,"T-Shirt",320,1,new List<int>(list1)),
        //     new Item(2,"T-Shirt med Print",450,1,new List<int>(list2)),
        //     new Item(3,"T-Shirt med Print",300,1,new List<int>(list3)),
        //     new Item(4,"T-Shirt",700,1,new List<int>(list4)),
        // };
        // foreach (var item in items)
        // {
        //     _itemRepository.CreateNewItem(item);
        // }
        
    }


    public ItemDTO UpdateItem(int id, ItemDTO itemDto)
    {
        if (id != itemDto.Id)
            throw new ValidationException("ID in body and route are different");
        var validation = _itemDtoValidator.Validate(itemDto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        var item = new Item(itemDto.Id, itemDto.Name, itemDto.Image, itemDto.Price, itemDto.ItemCategoryId);
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

    

    public ItemCategoryDTO CreateNewCategory(ItemCategoryDTO dto)
    {
        var validation = _postValidatorCategory.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        var category = new Category(dto.CategoryName);
        category = _categoryRepository.CreateNewCategory(category);
        return new ItemCategoryDTO(category);
    }

    public List<ItemCategoryDTO> GetAllCategories()
    {
        var catagorys = _categoryRepository.GetAllCategories();
        var catagoryDtos = new List<ItemCategoryDTO>();
        foreach (var catagory in catagorys)
        {
            catagoryDtos.Add(new ItemCategoryDTO(catagory));
        }
        return catagoryDtos;
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
        var options = GetAllOptions();
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