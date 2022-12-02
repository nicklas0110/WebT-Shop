using WebShopApplication;
using WebShopApplication.DTOs;
using WebShopApplication.Interfaces;
using WebsShopDomain;

namespace WebShopUnitTest;
using Moq;


public class UnitTest1
{
/*
    [Fact]
    public void CreateWebShopServiceWithRepository()
    {
        // Arrange
        Mock<IWebShopItemRepository> mockRepository = new Mock<IWebShopItemRepository>();
        IWebShopItemRepository repository = mockRepository.Object;

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
    } */

    [Fact]
    public void CreateItem()
    {
        // Arrange
        Item tshirt = new Item() { Name = "tshirt med tryk", Price = 399 };
        Mock<IWebShopItemRepository> mockRepo = new Mock<IWebShopItemRepository>();

        // Act, Assert
        mockRepo.Setup(r => r.CreateNewItem(tshirt)).Returns(tshirt);
        
        
    }

    [Fact]
    public void CreateItemFail()
    {
        // Arrange
        Item tshirt = new Item() { };
        Mock<IWebShopItemRepository> mockRepo = new Mock<IWebShopItemRepository>();
        mockRepo = null;
        
        // Assert, Act
        Assert.Null(mockRepo);

    }
    
    [Fact]
    public void GetallItems() 
    {
        // Arrange
        List<Item> fakeRepo = new List<Item>
        {
            new Item() {  Name = "tshirt med tryk", Price = 399},
            new Item() {  Name = "tshirt med tryk2", Price = 399},
        };

        // Act
        Mock<IWebShopItemRepository> mockRepo = new Mock<IWebShopItemRepository>();
        mockRepo.Setup(r => r.GetAllItems()).Returns(fakeRepo);

        // Assert
        Assert.NotNull(mockRepo);
    }
    
    [Fact]
    public void GetAllItemFail()
    {
        // Arrange
        List<Item> fakeRepo = new List<Item>
        {
        };

        // Act
        Mock<IWebShopItemRepository> mockRepo = new Mock<IWebShopItemRepository>();
        mockRepo.Setup(r => r.GetAllItems()).Returns(fakeRepo);
        
        // Assert
        Assert.Empty(fakeRepo);
        Assert.NotNull(fakeRepo);
    }
    //
    // [Fact]
    // public void GetAllCategories()
    // {
    //     // Arrange
    //     List<Category> fakeRepo = new List<Category>
    //     {
    //         new Category() {  CategoryName = "tshirt med tryk" },
    //         new Category() {  CategoryName = "tshirt med tryk" },
    //     };
    //
    //     // Act
    //     Mock<IWebShopCategoryRepository> mockRepo = new Mock<IWebShopCategoryRepository>();
    //     mockRepo.Setup(r => r.GetAllCategories()).Returns(fakeRepo);
    //
    //     // Assert
    //     Assert.NotNull(mockRepo);
    // }
    
    // [Theory]
    // public void GetAllCategoryFail()
    // {
    //     // Arrange
    //     List<Category> fakeRepo = new List<Category>
    //     {
    //     };
    //
    //     // Act
    //     Mock<IWebShopCategoryRepository> mockRepo = new Mock<IWebShopCategoryRepository>();
    //     mockRepo.Setup(r => r.GetAllCategories(deleteAt,updatedAt)).Returns(fakeRepo);
    //     
    //     // Assert
    //     Assert.Empty(fakeRepo);
    //     Assert.NotNull(fakeRepo);
    // }
    
    [Fact]
    public void GetAllOptiones()
    {
        // Arrange
        List<Option> fakeRepo = new List<Option>
        {
            new Option() {  Name = "tshirt med tryk" },
            new Option() {  Name = "tshirt Uden tryk" },
        };

        // Act
        Mock<IWebShopOptionRepository> mockRepo = new Mock<IWebShopOptionRepository>();
        mockRepo.Setup(r => r.GetAllOptions()).Returns(fakeRepo);

        // Assert
        Assert.NotNull(mockRepo);
    }
    
    [Fact]
    public void GetAllOptionFail()
    {
        // Arrange
        List<Option> fakeRepo = new List<Option>
        {
            
        };

        // Act
        Mock<IWebShopOptionRepository> mockRepo = new Mock<IWebShopOptionRepository>();
        mockRepo.Setup(r => r.GetAllOptions()).Returns(fakeRepo);
        
        // Assert
        Assert.Empty(fakeRepo);
        Assert.NotNull(fakeRepo);

    }
    
    [Fact]
    public void UpdateItem()
    {
        // Arrange
        Item tshirt1 = new Item() { Id = 1, Name = "tshirt med tryk", Price = 399 };
        Item tshirt2 = new Item() { Id = 1, Name = "tshirt uden tryk", Price = 499 };

        // Act
        Mock<WebShopService> mockRepo = new Mock<WebShopService>();
        //mockRepo.Setup(i => i.UpdateItem(tshirt1.Id, tshirt2));
        var item = mockRepo.Setup(i => i.UpdateItem(tshirt1.Id, tshirt2));
        
        
        // Assert
        Assert.Same(tshirt1, tshirt2);

    }
    
    
    // [Fact]
    // public void ViLeger()
    // {
    //     
    //     
    //     // Arrange
    //     var optionGroups = new List<OptionGroup>()
    //     {
    //         new OptionGroup()
    //         {
    //             Id = 1,
    //             Name = "Farve"
    //         },
    //         new OptionGroup()
    //         {
    //             Id = 2,
    //             Name = "Størelse"
    //         }
    //     };
    //     var options = new List<Option>()
    //     {
    //         new Option()
    //         {
    //             Id = 1,
    //             Name = "Rød",
    //             Group = optionGroups.First(og => og.Name == "Farve")
    //         },
    //         new Option()
    //         {
    //             Id = 2,
    //             Name = "Gul",
    //             Group = optionGroups.First(og => og.Name == "Farve")
    //         },
    //         new Option()
    //         {
    //             Id = 3,
    //             Name = "Grøn",
    //             Group = optionGroups.First(og => og.Name == "Farve")
    //         },
    //         new Option()
    //         {
    //             Id = 4,
    //             Name = "S",
    //             Group = optionGroups.First(og => og.Name == "Størelse")
    //         },
    //         new Option()
    //         {
    //             Id = 5,
    //             Name = "M",
    //             Group = optionGroups.First(og => og.Name == "Størelse")
    //         },
    //         new Option()
    //         {
    //             Id = 6,
    //             Name = "L",
    //             Group = optionGroups.First(og => og.Name == "Størelse")
    //         },
    //         new Option()
    //         {
    //             Id = 7,
    //             Name = "Xl",
    //             Group = optionGroups.First(og => og.Name == "Størelse")
    //         }
    //     };
    //     
    //     var itemCategory = new Category()
    //     {
    //         Id = 1,
    //         CategoryName = "Tshirt"
    //     };
    //     
    //     var HummelTshirt = new Item()
    //     {
    //         Id = 1,
    //         Name = "Hummel tshirt",
    //         Price = 299.99m,
    //         Options = options,
    //         ItemCategoryId = itemCategory.Id,
    //         ItemCategory = itemCategory
    //     };
    //     var AdidasTshirt = new Item()
    //     {
    //         Id = 1,
    //         Name = "Adidas tshirt",
    //         Price = 399.99m,
    //         Options = options,
    //         ItemCategoryId = itemCategory.Id,
    //         ItemCategory = itemCategory
    //     };
    //     
    //     
    //     Item item = new Item() { Name = "tshirt med tryk", Price = 399, ItemCategoryId = 1 };
    //     Mock<IWebShopItemRepository> mockRepo = new Mock<IWebShopItemRepository>();
    //
    //     // Act, Assert
    //     mockRepo.Setup(r => r.CreateNewItem(item)).Returns(item);
    //
    // }
    
    
    
    
}