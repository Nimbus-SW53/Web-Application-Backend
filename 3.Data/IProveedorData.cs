namespace _3.Data.Model;

public interface IProveedorData
{
    Proveedores GetById(int id);

    Proveedores GetByName(string name);

    List<Proveedores>GetAll();

    bool Create(Proveedores proveedores);

    bool Update(Proveedores proveedores, int id);


    bool Delete(int id);
}