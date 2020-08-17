using System.ComponentModel.DataAnnotations;

public class Product
{
    public long Id { get; set; }

    [Required]
    [StringLength(25)]
    public string Name { get; set; }

    [Range(0.01, 10000)]
    public decimal Price { get; set; }

    public string Description {get;set;}
}