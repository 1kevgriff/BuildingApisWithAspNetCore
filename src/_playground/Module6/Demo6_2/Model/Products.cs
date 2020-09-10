using System.ComponentModel.DataAnnotations;

public class Product
{
    public long Id { get; set; }

    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    
    [Range(0.01, 10000)]
    public decimal Price { get; set; }

    [EmailAddress] // name@domain.tld
    public string ContactEmailAddress {get;set;}
}