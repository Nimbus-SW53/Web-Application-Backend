namespace _1._API.Request;
using System.ComponentModel.DataAnnotations;

public class CategoryRequest
{
    [Required]
    [MaxLength(120)]
    public string CategoryName { get; set; }
}