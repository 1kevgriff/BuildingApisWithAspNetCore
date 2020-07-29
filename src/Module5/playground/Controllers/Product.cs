using Microsoft.AspNetCore.Mvc;

public class Product
{
    public long Id { get; set; }

    [FromHeader(Name = "X-Kevin")]
    public string Name { get; set; }

    [FromBody]
    public decimal Price { get; set; }

    [FromBody]
    public string Description {get;set;}
}