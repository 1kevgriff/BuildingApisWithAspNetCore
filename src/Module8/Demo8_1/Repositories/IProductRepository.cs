
using System.Collections.Generic;

public interface IProductRepository
{
    IEnumerable<Product> GetProducts();
    Product GetProductById(long id);

    Product CreateProduct(Product newProduct);
    void UpdateProduct(long id, Product updatedProduct);
    void DeleteProduct(long id);
}