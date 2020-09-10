# Model Binding

```csharp
[HttpPost("")]
public IActionResult CreateNewProduct([FromBody] Product newProduct)
{
    // create product...
    var createdProduct = _productRepository.CreateProduct(newProduct);

    return CreatedAtAction(nameof(GetProductById), new {id = createdProduct.Id}, createdProduct);
}
```

## Add XML

```csharp
    services.AddControllers().AddXmlSerializerFormatters();
```

```csharp
[HttpPost("")]
public IActionResult CreateNewProduct([FromForm] Product newProduct)
{
    // create product...
    var createdProduct = _productRepository.CreateProduct(newProduct);

    return CreatedAtAction(nameof(GetProductById), new {id = createdProduct.Id}, createdProduct);
}
```

```csharp
public IActionResult GetProducts([FromQuery]int page = 1, [FromQuery]int pageSize = 50)
{
    var products = _productRepository.GetProducts();

    return Ok(products);
}
```

[FromHeader]
```csharp
public IActionResult GetProducts([FromHeader(Name = "X-HeaderTest")] string headerTest)
{
    var products = _productRepository.GetProducts();

    return Ok(products);
}

```
