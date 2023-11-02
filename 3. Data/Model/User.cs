using System.Text.Json.Serialization;
namespace _3._Data.Model;

public class User: ModelBase
{
    public string FullName { get; set; }
    public string UserName { get; set; }
    
    [JsonIgnore]
    public string? UrlAvatar { get; set; }
    
    public string Email { get; set; }
    
    [JsonIgnore]
    public string Password { get; set; }
    
    [JsonIgnore]
    public List<Review> Reviews { get; set; }
}