using _3.Data.Model;

namespace _2.Domain;

public interface IProveedorDomain
{
    bool Create(Proveedores proveedores);

    bool Update(Proveedores proveedores, int id);
    
    bool Delete(int id);
    
    
}