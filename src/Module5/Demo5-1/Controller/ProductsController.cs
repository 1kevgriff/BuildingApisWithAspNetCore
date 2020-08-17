using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    // GET /api/products

    // POST /api/products
    [HttpPost("")]
    public IActionResult CreateNewProduct([FromForm] Product newProduct)
    {
        // create product...

        return Ok(newProduct);
    }

    // DELETE /api/products/{id}
    [HttpDelete("{id}")]
    public IActionResult UpdateProduct(long id)
    {
        // delete product data...
        
        return Ok();
    }
}