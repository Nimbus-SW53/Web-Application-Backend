using _3._Data.Model;
namespace _3._Data;

public interface IProviderData
{
    Provider GetById(int id);
    Provider GetByName(string name);
    
    Task<List<Provider>> GetAllAsync();
    
    bool Create(Provider provider);
    bool Update(Provider provider,int id);
    bool Delete(int id);
}