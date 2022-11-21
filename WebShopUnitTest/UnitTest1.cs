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
        TShirt[] fakeRepo = new TShirt[]
        {
            new TShirt() { size = "12", type = "V-Neck", color = "Blue"},
            new TShirt() { size = "M", type = "V-Neck", color = "Black"},
        };
        
        // Act
        Mock<IWebShopRepository> mockRepo = new Mock<IWebShopRepository>();
        mockRepo.Setup(r => r.GetAll()).Returns(fakeRepo);
        
        // Assert
        Assert.NotNull(mockRepo);
    }
    
    

    
}

