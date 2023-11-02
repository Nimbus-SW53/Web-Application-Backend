namespace _3._Data.Model;
using System.Text.Json.Serialization;

public class ModelBase
{
    [JsonIgnore]
    public int Id { get; set; }
    [JsonIgnore]
    public DateTime DateCreated { get; set; }
    [JsonIgnore]
    public DateTime? DateUpdate { get; set; }
    [JsonIgnore]
    public bool IsActive { get; set; }
}