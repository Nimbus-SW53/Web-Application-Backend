using _3.Data.Context;

namespace _3.Data.Model;

public class ProveedorMySQLData:IProveedorData
{

    private NimbusCenterDB _nimbusCenterDb;

    public ProveedorMySQLData(NimbusCenterDB nimbusCenterDb)
    {
        _nimbusCenterDb = nimbusCenterDb;
    }
    public Proveedores GetById(int id)
    {
        return _nimbusCenterDb.Proveedores.Where(p => p.Id == id && p.IsActive).First();
    }

    public Proveedores GetByName(string name)
    {
        return _nimbusCenterDb.Proveedores.Where(p => p.Name == name && p.IsActive).FirstOrDefault();
    }

    public List<Proveedores> GetAll()
    {
        return _nimbusCenterDb.Proveedores.Where(p=>p.IsActive==true).ToList();
    }

    public bool Create(Proveedores proveedores)
    {
        try
        {
            _nimbusCenterDb.Proveedores.Add(proveedores);
            _nimbusCenterDb.SaveChanges();
            return true;

        }
        catch (Exception error)
        {
            return false;
        }
       
    }
    
    public bool Update(Proveedores proveedores, int id)
    {
        try
        {
            var update=_nimbusCenterDb.Proveedores.Where(p=>p.Id ==id).First();

            update.Name = proveedores.Name;
            update.Year = proveedores.Year;
            update.Cost = proveedores.Cost;
            update.Reviews = proveedores.Reviews;
            update.DateUpdate=DateTime.Now;


            _nimbusCenterDb.Proveedores.Update(update);
            _nimbusCenterDb.SaveChanges();
            
            return true;

        }
        catch (Exception error)
        {
            return false;
        }
       
    }

    public bool Delete(int id)
    {
        try
        {
            var remove=_nimbusCenterDb.Proveedores.Where(p=>p.Id ==id).First();

            _nimbusCenterDb.Proveedores.Remove(remove);
            
            _nimbusCenterDb.SaveChanges();            
            
            return true;

        }
        catch (Exception error)
        {
            return false;
        }
    }
}