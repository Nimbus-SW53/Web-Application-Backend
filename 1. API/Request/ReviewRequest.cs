using System.ComponentModel.DataAnnotations;
namespace _1._API.Request;

public class ReviewRequest
{   
    [Required]
    [Range(1, 5)]
    public float Score { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public int ProductId { get; set;} 
}