namespace _3.Data.Model;

public class Category :ModelBase
{
    public string Title { get; set; }
    public string Description { get; set;}

    private List<Proveedores> _proveedores { get; set; }

}


