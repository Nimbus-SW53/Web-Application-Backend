namespace _1._API.Request;
using System.ComponentModel.DataAnnotations;

public class UserRequest
{   
    [Required]
    [MaxLength(100)]
    public string FullName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string UserName { get; set; }
    
    public string? UrlAvatar { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
}