
using System.Collections.Generic;

public interface IProductRepository
{
    List<Product> GetProducts();
    Product CreateProduct(Product newProduct);
}