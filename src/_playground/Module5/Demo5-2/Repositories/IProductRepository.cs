
using System.Collections.Generic;

public interface IProductRepository
{
    List<Product> GetProducts();
    Product GetProduct(long id);
    Product CreateProduct(Product newProduct);
}