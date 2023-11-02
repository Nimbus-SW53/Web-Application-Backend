using _1._API.Request;
using _1._API.Response;
using _3._Data.Model;
using AutoMapper;
namespace _1._API.Mapper;

public class ProductModelToAPI: Profile
{
    public ProductModelToAPI()
    {
        CreateMap<Product, ProductRequest>();
        CreateMap<Product, ProductResponse>();
    }
}