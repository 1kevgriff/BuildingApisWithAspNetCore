

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{

    // GET /api/products

    // POST /api/products
    [HttpPost("")]
    public IActionResult CreateNewProduct(Product newProduct)
    {

    }

}