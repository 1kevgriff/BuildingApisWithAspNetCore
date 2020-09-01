using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/products")]
[FormatFilter]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }

    [HttpGet("")]
    public IActionResult GetProducts()
    {
        var products = _productRepository.GetProducts();

        return Ok(products);
    }

    // api/products/1.json
    // api/products/1.xml
    [HttpGet("{id}.{format?}")]
    public IActionResult GetProductById(long id)
    {
        var product = _productRepository.GetProduct(id);
        if (product == null) return NotFound();

        return Ok(product);
    }

    // POST /api/products
    [HttpPost("")]
    public IActionResult CreateNewProduct([FromBody]Product newProduct)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        // create product...
        var createdProduct = _productRepository.CreateProduct(newProduct);

        return CreatedAtAction(nameof(GetProductById),
            new { id = createdProduct.Id },
            createdProduct);
    }
}