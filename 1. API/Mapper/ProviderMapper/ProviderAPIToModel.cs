using _1._API.Request;
using _3._Data.Model;
using AutoMapper;
namespace _1._API.Mapper.ProviderMapper;

public class ProviderAPIToModel: Profile
{
    public ProviderAPIToModel()
    {
        CreateMap<ProductRequest, Provider>();
    }
}