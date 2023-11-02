using _3.Data.Model;

namespace _2.Domain;

public class ProveedorDomain:IProveedorDomain
{

    private IProveedorData _proveedorData;

    public ProveedorDomain(IProveedorData proveedorData)
    {
        _proveedorData = proveedorData;
    }

    public bool Create(Proveedores proveedores)
    {
        var existe = _proveedorData.GetByName(proveedores.Name);

        if (existe==null)
        {
            return _proveedorData.Create(proveedores);
        }
        else
        {
            return false;
        }
    }

    public bool Update(Proveedores proveedores, int id)
    {
        var existe = _proveedorData.GetByName(proveedores.Name);

        if (existe==null)
        {
            return _proveedorData.Update(proveedores,id);
        }
        else
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        return _proveedorData.Delete(id);
    }
}