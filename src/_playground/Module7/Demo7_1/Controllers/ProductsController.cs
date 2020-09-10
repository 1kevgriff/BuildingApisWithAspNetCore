using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;


// api/1.1/products
[ApiController]
[Route("/api/products")]
[Route("/api/{version:apiVersion}/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }

    [HttpGet("")]
    [ApiVersion("1.0")]
    public List<Product> GetProducts()
    {
        var products = _productRepository.GetProducts();

        return products; // 200 OK
    }

    [HttpGet("")]
    [ApiVersion("1.1")]
    public List<Product> GetProducts([FromQuery] string filter)
    {
        var products = _productRepository.GetProducts();

        return products; // 200 OK
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProductById(long id)
    {
        var product = _productRepository.GetProduct(id);

        if (product == null) return NotFound();

        return product;
    }
}