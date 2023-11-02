using _3._Data.Model;
namespace _3._Data;

public interface IProductData
{
    Product GetById(int id);
    Product GetBySoftwareName(string name);
    
    Task<List<Product>> GetAllAsync();
    Task<List<Product>> GetAllByCategoryAsync(int categoryId);
    Task<List<Product>> GetAllByPriceAsync(decimal price);
    Task<List<Product>> GetAllByCategoryAndPriceAsync(int categoryId, decimal price);
    
    bool Create(Product product);
    bool Update(Product product,int id);
    bool Delete(int id);
}