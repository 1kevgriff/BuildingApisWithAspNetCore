
using System.Collections.Generic;
using System.Linq;

public class FakeProductRepository : IProductRepository
{
    private static List<Product> _products = new List<Product>();

    static FakeProductRepository()
    {
        _products.Add(new Product()
        {
            Id = 0,
            Name = "Log",
            Description = "It's log, it's log.  It's big, it's heavy, it's wood."
        });
    }

    public Product CreateProduct(Product newProduct)
    {
        newProduct.Id = _products.Max(p => p.Id) + 1;
        _products.Add(newProduct);

        return newProduct;
    }

    public List<Product> GetProducts()
    {
        return _products;
    }
}