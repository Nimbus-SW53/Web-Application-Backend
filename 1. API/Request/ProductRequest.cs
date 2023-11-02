namespace _1._API.Request;
using System.ComponentModel.DataAnnotations;

public class ProductRequest
{
    [Required]
    [MaxLength(100)]
    public string SoftwareName { get; set; }

    [Required]
    public decimal Price { get; set; }

    //public List<string>? UrlImages { get; set; }

    [Required]
    [MaxLength(500)]
    public string Description { get; set; }

    [Required]
    public string UrlImagePreview { get; set; }

    [Required]
    public int CategoryId { get; set; }
}