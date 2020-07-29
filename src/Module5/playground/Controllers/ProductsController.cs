

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class ProductsController : ControllerBase
{
    [HttpPost("/api/products")]
    public IActionResult CreateNewProduct([FromForm]Product newProduct)
    {
        return Ok();
    }
}