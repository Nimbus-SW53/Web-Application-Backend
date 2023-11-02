using _3._Data.Context;
using _3._Data.Model;
namespace _3._Data.Repositories;
using Microsoft.EntityFrameworkCore;

public class CategoryMySQLData: ICategoryData
{
    private NimbusDB _nimbusDb;
    
    public CategoryMySQLData(NimbusDB nimbusDb)
    {
        _nimbusDb = nimbusDb;
    }
    
    public Category GetById(int id)
    {
        return _nimbusDb.Categories.Where(c => c.Id == id && c.IsActive).First();

    }

    public Category GetByName(string name)
    {
        return _nimbusDb.Categories.Where(c => c.CategoryName == name && c.IsActive).FirstOrDefault();
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _nimbusDb.Categories.Where(c => c.IsActive).ToListAsync();
    }

    public bool Create(Category category)
    {
        try
        {
            _nimbusDb.Categories.Add(category);
            _nimbusDb.SaveChanges();
            return true;
        }
        catch (Exception error)
        {
            return false;
        }
    }

    public bool Update(Category category, int id)
    {
        try
        {
            var categoryToBeUpdated = _nimbusDb.Categories.Where(c => c.Id == id).First();

            categoryToBeUpdated.CategoryName = category.CategoryName;
            categoryToBeUpdated.DateUpdate = DateTime.Now;
            
            _nimbusDb.Categories.Update(categoryToBeUpdated);
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
            var categoryToBeUpdated = _nimbusDb.Categories.Where(c => c.Id == id).First();
            
            categoryToBeUpdated.DateUpdate = DateTime.Now;
            categoryToBeUpdated.IsActive = false;
            
            _nimbusDb.Categories.Update(categoryToBeUpdated);
            _nimbusDb.SaveChanges();
            
            return true;
        }
        catch (Exception error)
        {
            return false;
        }
    }
}