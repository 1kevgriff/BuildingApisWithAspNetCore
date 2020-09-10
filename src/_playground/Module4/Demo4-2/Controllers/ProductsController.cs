using Microsoft.AspNetCore.Mvc;

[Route("products")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }

    // GET /products
    [Route("")]
    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_productRepository.GetProducts());
    }

    // GET /products/1
    [HttpGet("{id:long:min(0):max(100)}")]
    public IActionResult GetProductById(long id)
    {
        var product = _productRepository.GetProduct(id);

        // product == null
        if (product == null) return NotFound(); // 404 NOT FOUND

        return Ok(product); // 200 OK
    }

    // POST /products
    [HttpPost("")]
    public IActionResult CreateProduct(Product newProduct)
    {
        var createdProduct = _productRepository.CreateProduct(newProduct);

        var createdUrl = $"/products/{createdProduct.Id}";

        return Created(createdUrl, createdProduct);
    }
}