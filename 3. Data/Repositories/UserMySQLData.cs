using _3._Data.Context;
using _3._Data.Model;

namespace _3._Data.Repositories;
using Microsoft.EntityFrameworkCore;

public class UserMySQLData:  IUserData
{
    private NimbusDB _nimbusDb;
    
    public UserMySQLData(NimbusDB nimbusDb)
    {
        _nimbusDb = nimbusDb;
    }


    public User GetById(int id)
    {
        return _nimbusDb.Users.Where(u => u.Id == id && u.IsActive).First();
    }

    public User GetByFullName(string fullname)
    {
        return _nimbusDb.Users.Where(u => u.FullName == fullname && u.IsActive).FirstOrDefault();
    }

    public User GetByUserName(string username)
    {
        return _nimbusDb.Users.Where(u => u.UserName == username && u.IsActive).FirstOrDefault();
    }

    public User GetByEmail(string email)
    {
        return _nimbusDb.Users.Where(u => u.Email == email && u.IsActive).FirstOrDefault();
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _nimbusDb.Users.Where(u => u.IsActive).ToListAsync();
    }

    public bool Create(User user)
    {
        try
        {
            _nimbusDb.Users.Add(user);
            _nimbusDb.SaveChanges();
            return true;
        }
        catch (Exception error)
        {
            return false;
        }
    }

    public bool Update(User user, int id)
    {
        try
        {
            var userToBeUpdated = _nimbusDb.Users.Where(u => u.Id == id).First();

            userToBeUpdated.FullName = user.FullName;
            userToBeUpdated.UserName = user.UserName;
            userToBeUpdated.Email = user.Email;
            userToBeUpdated.Password = user.Password;
            userToBeUpdated.DateUpdate = DateTime.Now;
            
            _nimbusDb.Users.Update(userToBeUpdated);
            _nimbusDb.SaveChanges();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            var userToBeUpdated = _nimbusDb.Users.Where(u => u.Id == id).First();
            
            userToBeUpdated.DateUpdate = DateTime.Now;
            userToBeUpdated.IsActive = false;
            
            _nimbusDb.Users.Update(userToBeUpdated);
            _nimbusDb.SaveChanges();
            
            return true;
        }
        catch (Exception error)
        {
            return false;
        }
    }
}