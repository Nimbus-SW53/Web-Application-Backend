using _3._Data.Model;
namespace _3._Data;

public interface IUserData
{
    User GetById(int id);
    User GetByFullName(string fullname);
    User GetByUserName(string username);
    User GetByEmail(string email);
    
    Task<List<User>> GetAllAsync();
    
    bool Create(User user);
    bool Update(User user,int id);
    bool Delete(int id);
}