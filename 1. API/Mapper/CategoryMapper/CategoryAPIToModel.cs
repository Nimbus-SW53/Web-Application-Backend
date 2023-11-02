using _1._API.Request;
using _3._Data.Model;
using AutoMapper;
namespace _1._API.Mapper.CategoryMapper;

public class CategoryAPIToModel: Profile
{
    public CategoryAPIToModel ()
    {
        CreateMap<CategoryRequest, Category>();
    }
}