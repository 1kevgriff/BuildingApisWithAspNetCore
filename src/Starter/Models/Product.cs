
using System.ComponentModel.DataAnnotations;

public class Product
{
    public long Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [Required]
    [MaxLength(1024)]
    public string Description { get; set; }

    [Required]
    [Range(0, 1000.0)]
    public decimal Price { get; set; }
}
