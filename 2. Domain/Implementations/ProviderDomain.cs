using System.Security.AccessControl;
using _3._Data;
using _3._Data.Model;
namespace _2._Domain;

public class ProviderDomain: IProviderDomain
{
    private IProviderData _providerData;

    public ProviderDomain(IProviderData providerData)
    {
        _providerData = providerData;
    }
    
    public bool Create(Provider provider)
    {
        var existingProvider = _providerData.GetByName(provider.Name);

        if (existingProvider == null)
        {
            return _providerData.Create(provider);
        }
        else
        {
            return false;
        }
    }

    public bool Update(Provider provider, int id)
    {
        var existingProvider = _providerData.GetById(id);
        if (existingProvider == null) throw new Exception("Provider not found");
        
        var providerWithSameName = _providerData.GetByName(provider.Name);
        
        //Verificar si el proveedor con el mismo nombre es el mismo proveedor
        // Si el proveedor existe, pero no es el mismo proveedor Id != id
        if (providerWithSameName != null && providerWithSameName.Id != id)
        {
            // Si existe otro proveedor con el mismo nombre, retornar false
            //throw new Exception("A provider with this name already exists");
            return false;
        }
        else
        {
            return _providerData.Update(provider, id);
        }
    }

    public bool Delete(int id)
    {
        var provider = _providerData.GetById(id);
        if (provider != null)
        {
            return _providerData.Delete(id);
        }
        else
        {
            return false;
        }
    }
}