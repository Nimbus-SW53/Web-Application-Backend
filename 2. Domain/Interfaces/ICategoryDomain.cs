using _3._Data.Model;
namespace _2._Domain;

public interface ICategoryDomain
{
    bool Create(Category category);
    bool Update(Category category,int id);
    bool Delete(int id);
}