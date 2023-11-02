using _1._API.Request;
using _1._API.Response;
using _3._Data.Model;
using AutoMapper;
namespace _1._API.Mapper.ProviderMapper;

public class ProviderModelToAPI: Profile
{
    public ProviderModelToAPI()
    {
        CreateMap<Provider, ProviderRequest>();
        CreateMap<Provider, ProviderResponse>();
    }
}