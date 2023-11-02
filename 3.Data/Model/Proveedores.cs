namespace _3.Data.Model;

public class Proveedores :ModelBase
{
  public string Name { get; set; }

  public int Year { get; set; }

  public float Cost { get; set; }
  
  public int? Reviews { get; set; }
  
}