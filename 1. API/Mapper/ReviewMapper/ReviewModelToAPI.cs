using _1._API.Request;
using _1._API.Response;
using _3._Data.Model;
using AutoMapper;
namespace _1._API.Mapper.ReviewMapper;

public class ReviewModelToAPI: Profile
{
    public ReviewModelToAPI()
    {
        CreateMap<Review, ReviewRequest>();
        CreateMap<Review, ReviewResponse>();
    }
}