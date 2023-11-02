using _3._Data.Model;
namespace _3._Data;

public interface ICategoryData
{
    Category GetById(int id);
    Category GetByName(string name);
    
    Task<List<Category>> GetAllAsync();
    
    bool Create(Category category);
    bool Update(Category category,int id);
    bool Delete(int id);
}