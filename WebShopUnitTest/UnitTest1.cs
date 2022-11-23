using WebShopApplication;
using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopUnitTest;
using Moq;


public class UnitTest1
{

    [Fact]
    public void CreateWebShopServiceWithRepository()
    {
        // Arrange
        Mock<IWebShopRepository> mockRepository = new Mock<IWebShopRepository>();
        IWebShopRepository repository = mockRepository.Object;

        // Act
        IWebShopService service = new WebShopService(repository);

        // Assert
        Assert.NotNull(service);
        Assert.True(service is WebShopService);
    }


    [Fact]
    public void CreateWebShopServiceWithNoRepositoryExceptArgumentException()
    {
        // Arrange
        IWebShopService service = null;

        // Act + Assert
        var ex = Assert.Throws<ArgumentException>(() => service = new WebShopService(null));

        Assert.Equal("Missing repository", ex.Message);
        Assert.Null(service);
    }

    [Fact]
    public void CreateItem()
    {
        // Arrange
        Item tshirt = new Item() { Name = "tshirt med tryk", Price = 399, ItemCategoryId = 1 };
        Mock<IWebShopRepository> mockRepo = new Mock<IWebShopRepository>();

        // Act, Assert
        mockRepo.Setup(r => r.CreateNewItem(tshirt)).Returns(tshirt);

    }

    [Fact]
    public void CreateItemFail()
    {
        // Arrange
        Item[] fakeRepo = new Item[]
        {
            new Item() {  Name = "tshirt med tryk", Price = 399, ItemCategoryId = 1 },
            new Item() {  Name = "tshirt med tryk2", Price = 399, ItemCategoryId = 2 },
        };

        // Act
        Mock<IWebShopRepository> mockRepo = new Mock<IWebShopRepository>();
        mockRepo = null;
        
        // Assert
        Assert.Null(mockRepo);
        
    }
    
    [Fact]
    public void GetallItems()
    {
        // Arrange
        Item[] fakeRepo = new Item[]
        {
            new Item() {  Name = "tshirt med tryk", Price = 399, ItemCategoryId = 1 },
            new Item() {  Name = "tshirt med tryk2", Price = 399, ItemCategoryId = 2 },
        };

        // Act
        Mock<IWebShopRepository> mockRepo = new Mock<IWebShopRepository>();
        mockRepo.Setup(r => r.GetAll()).Returns(fakeRepo);

        // Assert
        Assert.NotNull(mockRepo);
    }
    
    [Fact]
    public void GetAllItemFail()
    {
        // Arrange
        Item[] fakeRepo = new Item[]
        {
            new Item() {  Name = "tshirt med tryk", Price = 399, ItemCategoryId = 1 },
            new Item() {  Name = "tshirt med tryk2", Price = 399, ItemCategoryId = 2 },
        };

        // Act
        Mock<IWebShopRepository> mockRepo = new Mock<IWebShopRepository>();
        mockRepo = null;
        
        // Assert
        Assert.Null(mockRepo);
        
    }
    
    [Fact]
    public void ViLeger()
    {
        
        
        // Arrange
        var optionGroups = new List<OptionGroup>()
        {
            new OptionGroup()
            {
                Id = 1,
                Name = "Farve"
            },
            new OptionGroup()
            {
                Id = 2,
                Name = "Størelse"
            }
        };
        var options = new List<Option>()
        {
            new Option()
            {
                Id = 1,
                Name = "Rød",
                Group = optionGroups.First(og => og.Name == "Farve")
            },
            new Option()
            {
                Id = 2,
                Name = "Gul",
                Group = optionGroups.First(og => og.Name == "Farve")
            },
            new Option()
            {
                Id = 3,
                Name = "Grøn",
                Group = optionGroups.First(og => og.Name == "Farve")
            },
            new Option()
            {
                Id = 4,
                Name = "S",
                Group = optionGroups.First(og => og.Name == "Størelse")
            },
            new Option()
            {
                Id = 5,
                Name = "M",
                Group = optionGroups.First(og => og.Name == "Størelse")
            },
            new Option()
            {
                Id = 6,
                Name = "L",
                Group = optionGroups.First(og => og.Name == "Størelse")
            },
            new Option()
            {
                Id = 7,
                Name = "Xl",
                Group = optionGroups.First(og => og.Name == "Størelse")
            }
        };
        
        var itemCategory = new Category()
        {
            Id = 1,
            CategoryName = "Tshirt"
        };
        
        var HummelTshirt = new Item()
        {
            Id = 1,
            Name = "Hummel tshirt",
            Price = 299.99m,
            Options = options,
            ItemCategoryId = itemCategory.Id,
            ItemCategory = itemCategory
        };
        var AdidasTshirt = new Item()
        {
            Id = 1,
            Name = "Adidas tshirt",
            Price = 399.99m,
            Options = options,
            ItemCategoryId = itemCategory.Id,
            ItemCategory = itemCategory
        };
        
        
        Item item = new Item() { Name = "tshirt med tryk", Price = 399, ItemCategoryId = 1 };
        Mock<IWebShopRepository> mockRepo = new Mock<IWebShopRepository>();

        // Act, Assert
        mockRepo.Setup(r => r.CreateNewItem(item)).Returns(item);

    }
}