using _3._Data.Model;
namespace _2._Domain;

public interface IProviderDomain
{
    bool Create(Provider provider);
    bool Update(Provider provider,int id);
    bool Delete(int id);
}