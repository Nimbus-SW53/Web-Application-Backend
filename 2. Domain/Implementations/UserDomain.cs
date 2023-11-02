using _3._Data;
using _3._Data.Model;
namespace _2._Domain;

public class UserDomain: IUserDomain
{
    private IUserData _userData;

    public UserDomain(IUserData userData)
    {
        _userData = userData;
    }
    
    public bool Create(User user)
    {
        var existingUserName = _userData.GetByUserName(user.UserName);
        var existingEmail = _userData.GetByEmail(user.Email);
        
        if (existingUserName == null && existingEmail == null)
        {
            return _userData.Create(user);
        }
        else
        {
            return false;
        }
    }

    public bool Update(User user, int id)
    {
        var existingUser = _userData.GetById(id);
        if (existingUser == null) throw new Exception("User not found");

        var existingUserName = _userData.GetByUserName(user.UserName);
        var existingEmail = _userData.GetByEmail(user.Email);
        
        if (existingUserName != null && existingUserName.Id != id) { return false;}
        if (existingEmail != null && existingEmail.Id != id) {return false;}
        
        return _userData.Update(user, id);
    }

    public bool Delete(int id)
    {
        var user = _userData.GetById(id);
        if (user != null)
        {
            return _userData.Delete(id);
        }
        else
        {
            return false;
        }
    }
}