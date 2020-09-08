using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }

    [HttpGet("")]
    public IActionResult GetProducts()
    {
        var products = _productRepository.GetProducts();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(long id)
    {
        var product = _productRepository.GetProductById(id);

        if (product == null) return NotFound();

        return Ok(product);
    }

    [HttpPost("")]
    public IActionResult CreateNewProduct(Product newProduct)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var p = _productRepository.CreateProduct(newProduct);

        return CreatedAtAction(nameof(GetProductById), new { id = p.Id }, p);
    }
}