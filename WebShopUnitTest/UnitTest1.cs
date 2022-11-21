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
    public void CreateTShirt()
    {
        // Arrange
        TShirt tshirt = new TShirt() { size = "12", type = "V-Neck", color = "Blue" };
        Mock<IWebShopRepository> mockRepo = new Mock<IWebShopRepository>();

        // Act, Assert
        mockRepo.Setup(r => r.CreateNewTShirt(tshirt)).Returns(tshirt);

    }

    [Fact]
    public void CreateTShirtFail()
    {
        // Arrange
        TShirt[] fakeRepo = new TShirt[]
        {
            new TShirt() { size = "12", type = "V-Neck", color = "Blue" },
            new TShirt() { size = "M", type = "V-Neck", color = "Black" },
        };

        // Act
        Mock<IWebShopRepository> mockRepo = new Mock<IWebShopRepository>();
        mockRepo = null;
        
        // Assert
        Assert.Null(mockRepo);
        
    }
    
    [Fact]
    public void GetallTShirt()
    {
        // Arrange
        TShirt[] fakeRepo = new TShirt[]
        {
            new TShirt() { size = "12", type = "V-Neck", color = "Blue" },
            new TShirt() { size = "M", type = "V-Neck", color = "Black" },
        };

        // Act
        Mock<IWebShopRepository> mockRepo = new Mock<IWebShopRepository>();
        mockRepo.Setup(r => r.GetAll()).Returns(fakeRepo);

        // Assert
        Assert.NotNull(mockRepo);
    }
    
    [Fact]
    public void GetAllTShirtFail()
    {
        // Arrange
        TShirt[] fakeRepo = new TShirt[]
        {
            new TShirt() { size = "12", type = "V-Neck", color = "Blue" },
            new TShirt() { size = "M", type = "V-Neck", color = "Black" },
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
        
        
        TShirt tshirt = new TShirt() { size = "12", type = "V-Neck", color = "Blue" };
        Mock<IWebShopRepository> mockRepo = new Mock<IWebShopRepository>();

        // Act, Assert
        mockRepo.Setup(r => r.CreateNewTShirt(tshirt)).Returns(tshirt);

    }
}

