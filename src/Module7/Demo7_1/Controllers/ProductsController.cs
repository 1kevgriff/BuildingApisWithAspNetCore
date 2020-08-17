using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{version:apiVersion}/products")]
public class ProductsV1Controller : ControllerBase
{
    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = new List<Productv1>() {
            new Productv1() {Id = 0, Name = "Log", Description = "It's Big.  It's Heavy.  It's Wood.", Price = 9.99m},
            new Productv1() {Id = 1, Name = "Twig", Description = "It's a smaller log.", Price = 5.99m}
        };

        return Ok(products);
    }
}

[ApiController]
[ApiVersion("2.0")]
[Route("api/{version:apiVersion}/products")]
public class ProductsV2Controller : ControllerBase
{
    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = new List<Productv2>() {
            new Productv2() {Id = 0, Name = "Log", Description = "It's Big.  It's Heavy.  It's Wood.", Price = 9.99m, QuantityInStock = 50},
            new Productv2() {Id = 1, Name = "Twig", Description = "It's a smaller log.", Price = 5.99m, QuantityInStock = 233}
        };

        return Ok(products);
    }
}