using System.Text.Json.Serialization;
namespace _3._Data.Model;

/*Relacion uno a muchos entre Review y User
 Un usuario puede realizar muchas Review y una Review
 le pertenece a un solo usuario.*/
public class Review: ModelBase
{
    public float Score { get; set; }
    public string Description { get; set; }
    
    [JsonIgnore]
    public int UserId { get; set; }
    public User User { get; set; }
    
    [JsonIgnore]
    public int ProductId { get; set;} // FK
    public Product Product { get; set; } // propiedad de navegación, importante para relacionar Review con Product
}