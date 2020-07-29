# Module 5 Notes

## Data Manipulation

```csharp
// example3.png
[HttpPost("")]
public IActionResult CreateNewProduct([FromBody]Product newProduct)
{
    // ...
}
```

[HttpPost] - Create new entity
[HttpPut] - Replace an entity
[HttpDelete] - Delete an entity
[HttpPatch] - Patch/update an entity

## What is model binding?

Taking requests data and turning it into objects.

### Basic-binding

### Example: JSON to POCO

```json
// example2.png
{
  "id": -1,
  "name": "Wonder Thingy",
  "price": 9.99,
  "description": "It does everything you can possibly imagine."
}
```

```csharp
// example1.png
public class Product
{
    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description {get;set;}
}
```

[FromBody]

```csharp
    [HttpPost("/api/products")]
    public IActionResult CreateNewProduct([FromBody]Product newProduct)
    {
        return Ok();
    }
```

[FromQuery]

```csharp
    [HttpGet("/api/products")]
    public IActionResult GetProducts([FromQuery]int page,
            [FromQuery]int pageSize)
    {
        return Ok();
    }
```

[FromHeader]

```csharp
    [HttpPost("/api/products")]
    public IActionResult CreateNewProduct(Product newProduct,
        [FromHeader(Name = "X-ApplicationId")] string applicationId)
    {
        return Ok();
    }
```

[FromRoute]
```csharp
    [HttpGet("/api/products/{productId}")]
    public IActionResult GetProduct([FromRoute(Name="productId")] int pId)
    {
        return Content($"Product Id = {pId}");
    }
```

[FromForm]
```
TODO: example
```

## DEMO: Examples of Binding

## Model Validation

Ensure that incoming data is "good" data.

`https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations`

[Required]

[EmailAddress]

[Phone]

[RegularExpression] // if you hate yourself.

Model.IsValid

- Custom attributes are a thing.

## DEMO: Model Validation
