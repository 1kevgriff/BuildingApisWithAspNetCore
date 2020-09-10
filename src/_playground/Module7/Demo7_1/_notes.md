# Notes

## Startup.cs

## Url

```csharp
services.AddApiVersioning(setup => {
    setup.DefaultApiVersion = new ApiVersion(1, 0); 
    // setup.ApiVersionReader = new QueryStringApiVersionReader("version", "ver", "v");
    // setup.ApiVersionReader = new HeaderApiVersionReader("x-version");
    setup.ApiVersionReader = new UrlSegmentApiVersionReader();
});
```

## Query String

```csharp
services.AddApiVersioning(setup => {
    setup.DefaultApiVersion = new ApiVersion(1, 0); 
    setup.ApiVersionReader = new QueryStringApiVersionReader("version", "ver", "v");
    // setup.ApiVersionReader = new HeaderApiVersionReader("x-version");
    // setup.ApiVersionReader = new UrlSegmentApiVersionReader();
});
```

## Headers

```csharp
services.AddApiVersioning(setup => {
    setup.DefaultApiVersion = new ApiVersion(1, 0); 
    // setup.ApiVersionReader = new QueryStringApiVersionReader("version", "ver", "v");
    setup.ApiVersionReader = new HeaderApiVersionReader("x-version");
    // setup.ApiVersionReader = new UrlSegmentApiVersionReader();
});
```
