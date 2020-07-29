using System.ComponentModel.DataAnnotations;

public class Product
{
    public long Id { get; set; }

    [Required]
    [StringLength(25)]
    public string Name { get; set; }

    [Required]
    public decimal Price { get; set; }

    public string Description {get;set;}
}