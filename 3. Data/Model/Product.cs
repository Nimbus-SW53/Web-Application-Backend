using System.Text.Json.Serialization;
namespace _3._Data.Model;

/*Relación uno a muchos entre un producto y sus comentarios.
 Un producto puede tener muchos comentarios,
pero cada comentario está relacionado con un solo producto.*/

/*Relación uno a muchos entre un producto y sus category.
 Un producto solo puede tener una sola categoria y una
 categoria puede estar en varios productos*/

public class Product: ModelBase
{   
    public string SoftwareName { get; set; }
    public decimal Price { get; set; }
    //public List<String>? UrlImages { get; set; }
    public string Description { get; set; }
    
    public string UrlImagePreview{ get; set; }
    
    [JsonIgnore]
    public List<Review> Reviews { get; set; }
    
    [JsonIgnore]
    public int CategoryId { get; set;} //FK
    public Category Category{ get; set;}
}