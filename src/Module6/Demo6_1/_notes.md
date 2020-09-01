# Notes

```csharp
    [HttpGet("{id}")]
    public Product GetProductById(long id)
    {
        var product = _productRepository.GetProduct(id);

        return product;
    }
```

```csharp
    [HttpGet("{id}")]
    public ActionResult<Product> GetProductById(long id)
    {
        var product = _productRepository.GetProduct(id);

        if (product == null) return NotFound();

        return product;
    }
```
