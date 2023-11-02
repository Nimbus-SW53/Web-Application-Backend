using _3._Data.Model;
namespace _2._Domain;

public interface IProductDomain
{
    bool Create(Product product);
    bool Update(Product product,int id);
    bool Delete(int id);
}