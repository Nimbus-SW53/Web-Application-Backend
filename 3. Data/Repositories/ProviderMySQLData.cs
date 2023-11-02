using _3._Data.Context;
using _3._Data.Model;
namespace _3._Data.Repositories;
using Microsoft.EntityFrameworkCore;

public class ProviderMySQLData: IProviderData
{
    private NimbusDB _nimbusDb;
    
    public ProviderMySQLData(NimbusDB nimbusDb)
    {
        _nimbusDb = nimbusDb;
    }


    public Provider GetById(int id)
    {
        return _nimbusDb.Providers.Where(p => p.Id == id && p.IsActive).First();
    }

    public Provider GetByName(string name)
    {
        return _nimbusDb.Providers.Where(p => p.Name == name && p.IsActive).FirstOrDefault();
    }

    public async Task<List<Provider>> GetAllAsync()
    {
        return await _nimbusDb.Providers.Where(p => p.IsActive).ToListAsync();
    }

    public bool Create(Provider provider)
    {
        try
        {
            _nimbusDb.Providers.Add(provider);
            _nimbusDb.SaveChanges();
            return true;
        }
        catch (Exception error)
        {
            return false;
        }
    }

    public bool Update(Provider provider, int id)
    {
        try
        {
            var providerToBeUpdated = _nimbusDb.Providers.Where(p => p.Id == id).First();

            providerToBeUpdated.Name = provider.Name;
            providerToBeUpdated.UrlLogo = provider.UrlLogo;
            providerToBeUpdated.DateUpdate = DateTime.Now;
            
            _nimbusDb.Providers.Update(providerToBeUpdated);
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
            var providerToBeUpdated = _nimbusDb.Providers.Where(p => p.Id == id).First();
            
            providerToBeUpdated.DateUpdate = DateTime.Now;
            providerToBeUpdated.IsActive = false;
            
            _nimbusDb.Providers.Update(providerToBeUpdated);
            _nimbusDb.SaveChanges();
            
            return true;
        }
        catch (Exception error)
        {
            return false;
        }
    }
}