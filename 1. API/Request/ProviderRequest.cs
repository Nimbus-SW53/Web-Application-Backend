namespace _1._API.Request;
using System.ComponentModel.DataAnnotations;

public class ProviderRequest
{
    [Required]
    [MaxLength(90)]
    public string Name { get; set; }
    
    [Required]
    public string UrlLogo { get; set; }
}