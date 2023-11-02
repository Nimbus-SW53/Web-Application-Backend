using _3._Data;
using _3._Data.Model;
using NSubstitute;
namespace _2._Domain.Test;

public class ProductDomainTest
{
    [Theory]
    [InlineData("software name 1",99.35m,"fake 1", "https//software1.jpg")]
    [InlineData("software name 2",373.29m,"fake 2", "https//software2.jpg")]
    [InlineData("software name 3",49.21m,"fake 3", "https//software3.jpg")]
    public void Create_ValidProduct_ResultTrue(string softwareName,decimal price,string description, string urlImagePreview)
    {
        //Arrange
        Product product = new Product()
        {
            SoftwareName = softwareName,
            Price = price,
            Description = description,
            UrlImagePreview = urlImagePreview
        };
        
        var productDataMock = Substitute.For<IProductData>();

        productDataMock.GetBySoftwareName(product.SoftwareName).Returns((Product)null);
        productDataMock.Create(product).Returns(true);
        
        ProductDomain productDomain = new ProductDomain(productDataMock);

        
        //Act
        var actualResult = productDomain.Create(product);

        //Assert
        Assert.True(actualResult);

    }
    
    [Theory]
    [InlineData(0.0m)]
    [InlineData(-39.18m)]
    [InlineData(-123.99m)]
    public void Create_InvalidPrice_ResultFalse(decimal price)
    {
        //Arrange
        Product product = new Product()
        {
            Price = price
        };
        
        var productDataMock = Substitute.For<IProductData>();
        
        ProductDomain productDomain = new ProductDomain(productDataMock);
        
        //Act
        Action act= () => productDomain.Create(product);

        //Assert
        Assert.Throws<Exception>(act);
    }
}