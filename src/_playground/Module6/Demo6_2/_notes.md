```csharp
public void ConfigureServices(IServiceColleciton services){
    services.AddControllers().AddXmlSerializerFormatters();
}
```

```csharp
[ApiController]
[Route("api/products")]
[FormatFilter]
public class ProductsController : ControllerBase
{
```

```csharp
    [HttpGet("{id}.{format?}")]
    public IActionResult GetProductById(long id)
    {
        var product = _productRepository.GetProduct(id);
        if (product == null) return NotFound();

        return Ok(product);
    }
```