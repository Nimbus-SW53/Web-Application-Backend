using _1._API.Request;
using _1._API.Response;
using _3._Data.Model;
using AutoMapper;
namespace _1._API.Mapper.CategoryMapper;

public class CategoryModelToAPI: Profile
{
    public CategoryModelToAPI()
    {
        CreateMap<Category, CategoryRequest>();
        CreateMap<Category, CategoryResponse>();
    }
}