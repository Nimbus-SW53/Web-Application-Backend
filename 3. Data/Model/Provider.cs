using System.Text.Json.Serialization;
namespace _3._Data.Model;

public class Provider: ModelBase
{
    public string Name { get; set; }
    
    [JsonIgnore]
    public string UrlLogo { get; set; }
}