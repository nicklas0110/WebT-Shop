namespace WebShopUnitTest;
using Moq;


public class UnitTest1
{
    private IWebShopRepository Repository;

    public WebShopService(IWebShopRepository repository)
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
        ITShirtService service = new TShirtService(repository);
        
        // Assert
        Assert.NotNull(service);
        Assert.True(service is TShirtService);
    }
    
    [Fact]
    public void CreateReviewServiceWithNoRepositoryExceptArgumentException()
    {
        // Arrange
        ITShirtService service = null;

        // Act + Assert
        var ex = Assert.Throws<ArgumentException>(() => service = new TShirtService(null));

        Assert.Equal("Missing repository", ex.Message);
        Assert.Null(service);
    }
    
}

