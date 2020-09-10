

using System.Collections.Generic;
using System.Linq;

public class FakeProductRepository : IProductRepository
{
    private static List<Product> Products;
    static FakeProductRepository()
    {
        Products = new List<Product>();
        Products.Add(new Product() { Id = 0, Name = "Log", Description = "It's big. It's heavy. It's wood.", Price = 9.99m });
        Products.Add(new Product() { Id = 1, Name = "Twig", Description = "It's small. It's light. It's wood.", Price = 5.99m });
    }

    public Product CreateProduct(Product newProduct)
    {
        newProduct.Id = Products.Max(x => x.Id) + 1;
        Products.Add(newProduct);

        return newProduct;
    }

    public void DeleteProduct(long id)
    {
        Products.RemoveAt(Products.FindIndex(p => p.Id == id));
    }

    public Product GetProductById(long id)
    {
        return Products.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Product> GetProducts()
    {
        return Products;
    }

    public void UpdateProduct(long id, Product updatedProduct)
    {
        var index = Products.FindIndex(p => p.Id == id);

        updatedProduct.Id = id;
        Products[index] = updatedProduct;
    }
}