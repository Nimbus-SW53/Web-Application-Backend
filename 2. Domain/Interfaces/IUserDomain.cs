using _3._Data.Model;
namespace _2._Domain;

public interface IUserDomain
{
    bool Create(User user);
    bool Update(User user,int id);
    bool Delete(int id);
}