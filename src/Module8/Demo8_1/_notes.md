# API Documentation

## Startup

```csharp
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Product API",
        Description = "A simple API for products",
        TermsOfService = new Uri("https://consultwithgriff.com"),
        Contact = new OpenApiContact
        {
            Name = "Kevin Griffin",
            Email = "kevin@consultwithgriff.com",
            Url = new Uri("https://consultwithgriff.com"),
        }
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API");
});
```

## Controller

```csharp
 /// <summary>
    /// Returns products from the products repository.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/product
    ///
    /// </remarks> 
    /// <returns>An array of products.</returns>
    /// <response code="200">An array of products.</response>
    [HttpGet("")]
    [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
    [Produces("application/json", "application/xml")]
    public IActionResult GetProducts()
    {
        var products = _productRepository.GetProducts();

        return Ok(products);
    }

    /// <summary>
    /// Returns product from the products repository by its ID.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/product/10
    ///
    /// </remarks> 
    /// <returns>A product</returns>
    /// <response code="200">A product</response>
    /// <response code="404">A product with given Id could not be found.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Product), 200)]
    [ProducesResponseType(404)]
    [Produces("application/json", "application/xml")]
    public IActionResult GetProductById(long id)
    {
        var product = _productRepository.GetProductById(id);

        if (product == null) return NotFound();

        return Ok(product);
    }

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/product
    ///     {
    ///         "name": "Product Name",
    ///         "description": "Product Description",
    ///         "price": 199.50
    ///     }
    /// </remarks> 
    /// <returns>A product</returns>
    /// <response code="201">A newly created product</response>
    /// <response code="400">Product has invalid data.</response>
    [HttpPost("")]
    [ProducesResponseType(typeof(Product), 201)]
    [ProducesResponseType(400)]
    [Produces("application/json", "application/xml")]
    public IActionResult CreateNewProduct(Product newProduct)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var p = _productRepository.CreateProduct(newProduct);

        return CreatedAtAction(nameof(GetProductById), new { id = p.Id }, p);
    }
```