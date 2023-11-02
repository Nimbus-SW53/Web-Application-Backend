using _1._API.Request;
using _1._API.Response;
using _3._Data.Model;
using AutoMapper;

namespace _1._API.Mapper.UserMapper;

public class UserModelToAPI: Profile
{
    public UserModelToAPI()
    {
        CreateMap<User, UserRequest>();
        CreateMap<User, UserResponse>();
    }
}