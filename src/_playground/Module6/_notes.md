# Notes

## Introduction

## Types of Results

1. IActionResult

```csharp
public IActionResult GetProducts()
{
    var products = _productRepository.GetProducts();
    return Ok(products);
}
```

2. Typed Response

```csharp
public List<Product> GetProducts2(long id)
{
    return new List<Product>(); // 200 OK
}
```

3. ActionResult<T>

```csharp
[HttpGet("{id}")]
public async Task<ActionResult<Product>> GetProductById(long id)
{
    var product = await _productRepository.GetById(id);
    if (product == null) return NotFound();

    return product;
}
```

## Content Negotiation

1. Change the `Accept` header.  ASP.NET Core does this for you automatically if configure service is initialized properly.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers().AddXmlSerializerFormatters();
}
```

2. Format extensions

```csharp
[ApiController]
[Route("/api/products")]
[FormatFilter]
public class ProductController : ControllerBase
{
    [HttpGet("")]
    public IActionResult GetProducts1()
    {
        var products = new List<Product>(){
            new Product() { Id = 0, Name = "Log", Price = 1.99m, Description = "It's log."},
            new Product() { Id = 1, Name = "Log #2", Price = 5.99m, Description = "It's another log."},
        };

        return Ok(products);
    }

    [HttpGet("{id}.{format?}")]
    public IActionResult GetProducts1(long id)
    {
        var products = new List<Product>(){
            new Product() { Id = 0, Name = "Log", Price = 1.99m, Description = "It's log."},
            new Product() { Id = 1, Name = "Log #2", Price = 5.99m, Description = "It's another log."},
        };

        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();

        return Ok(product);
    }
}
```

## Error Handling

* 500 Internal Server Error is a catch all if something goes wrong
* Try to use acceptable HTTP status codes for errors, but only when the client can change their behavior.  

400s
    400 Bad Request
    403 Forbidden
    404 Not Found

* Conversation about error handling in APIs
  * Generic "web apps" return HTML-based error pages, no useful
  * Or out-of-the-box ASP.NET Core returns status code 500, but no details
  * https://tools.ietf.org/html/rfc7807

* .UseExceptionHandler("/error")
    * Generic 500, something happened.

```csharp
public class HomeController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error() => Problem();
```

* .UseExceptionHandle("/detailedError")
    * create a custom exception
    * if custom exception is thrown, override the title and description of Problem()

```csharp
    [Route("/error")]
    public IActionResult Error() => Problem(title: "...", detail: "...");
```

        
