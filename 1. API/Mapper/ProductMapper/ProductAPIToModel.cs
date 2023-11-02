using _1._API.Request;
using _3._Data.Model;
using AutoMapper;
namespace _1._API.Mapper.ProductMapper;

public class ProductAPIToModel: Profile
{
    public ProductAPIToModel ()
    {
        CreateMap<ProductRequest, Product>();
    }
}