using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }

    [HttpGet("")]
    public List<Product> GetProducts()
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