using _1._API.Controllers;
using _1._API.Response;
using _2._Domain;
using _3._Data;
using _3._Data.Model;
using AutoMapper;
namespace _1._API.Test.Controllers;
using NSubstitute;

public class ProductControllerTest
{
    [Fact]
    public async Task GetAsync_ReturnOk()
    {
        var productDomainMock = Substitute.For<IProductDomain>();
        
        var productDataMock = Substitute.For<IProductData>();
        List<Product> products = new List<Product>();
        products.Add(new Product() { SoftwareName = "Software Name 1", Price = 219.35m, Description = "Fake1" });
        products.Add(new Product() { SoftwareName = "Software Name 2", Price = 59.21m,  Description = "Fake2" });
        products.Add(new Product() { SoftwareName = "Software Name 3", Price = 100.49m, Description = "Fake2" });

        productDataMock.GetAllAsync().Returns(Task.FromResult(products));
        
        
        var mapperMock = Substitute.For<IMapper>();
        List<ProductResponse> productReponses = new List<ProductResponse>();
        productReponses.Add(new ProductResponse() { SoftwareName = "Software Name Fake 1", Price = 219.35m, Description = "Fake1" });
        productReponses.Add(new ProductResponse() { SoftwareName = "Software Name Fake 2", Price = 59.21m,  Description = "Fake2" });
        productReponses.Add(new ProductResponse() { SoftwareName = "Software Name Fake 3", Price = 100.49m, Description = "Fake2" });

        mapperMock.Map<List<Product>, List<ProductResponse>>(products).Returns(productReponses);
        

        ProductController productController = new ProductController(productDataMock,productDomainMock,mapperMock);
        var actualResult = await productController.GetAsync();
        

        
        Assert.Equal(3, actualResult.Count());
        Assert.Equal(219.35m, actualResult[0].Price);
        Assert.Equal(59.21m, actualResult[1].Price);
        Assert.Equal(100.49m, actualResult[2].Price);
    }
}