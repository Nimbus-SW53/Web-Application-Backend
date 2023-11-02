using System.Text.Json.Serialization;
namespace _3._Data.Model;

public class Category: ModelBase
{
    public string CategoryName { get; set; }
    
    [JsonIgnore]
    public List<Product> Products { get; set; } // Propiedad de navegacion
}