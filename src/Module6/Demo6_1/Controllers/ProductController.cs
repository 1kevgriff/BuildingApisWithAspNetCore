using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/products")]
[FormatFilter]
public class ProductController : ControllerBase
{
    [HttpGet("{id}.{format?}")]
    public IActionResult GetProductById(long id)
    {
        var products = new List<Product>() {
            new Product() { Id = 0, Price = 9.99m, Name = "Log", Description = "It's big. It's heavy. It's wood."},
            new Product() { Id = 1, Price = 5.99m, Name = "Twig", Description = "It's like Log Jr."}
        };

        var p = products.First(p=> p.Id == id);

        return Ok(products);
    }
}

public class HomeController : Controller
{
    [Route("/error")]
    public IActionResult Error([FromServices] IWebHostEnvironment webHostEnvironment)
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

        return Problem(
            detail: context.Error.StackTrace,
            title: context.Error.Message);
    }
}