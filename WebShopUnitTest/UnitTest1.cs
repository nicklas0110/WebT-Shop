using WebShopApplication;
using WebShopApplication.Interfaces;

namespace WebShopUnitTest;
using Moq;


public class UnitTest1
{
    private IWebShopRepository Repository;

    public UnitTest1(IWebShopRepository repository)
    {
        if (repository == null)
        {
            throw new ArgumentException("Missing repository");
        }
        Repository = repository;
    }
    
    [Fact]
    public void CreateTShirt()
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
    public void CreateReviewServiceWithNoRepositoryExceptArgumentException()
    {
        // Arrange
        IWebShopService service = null;

        // Act + Assert
        var ex = Assert.Throws<ArgumentException>(() => service = new WebShopService(null));

        Assert.Equal("Missing repository", ex.Message);
        Assert.Null(service);
    }
    
}

