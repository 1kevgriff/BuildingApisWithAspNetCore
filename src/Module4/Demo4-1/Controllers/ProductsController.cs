using Microsoft.AspNetCore.Mvc;

[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }

    // GET /products
    [Route("/products")]
    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_productRepository.GetProducts());
    }

    // POST /products
    [HttpPost("/products")]
    public IActionResult CreateProduct(Product newProduct)
    {
        var createdProduct = _productRepository.CreateProduct(newProduct);

        var createdUrl = $"/products/{createdProduct.Id}";

        return Created(createdUrl, createdProduct);
    }
}