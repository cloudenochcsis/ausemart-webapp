using ausemartweb.Models;

namespace ausemartweb.Services;

public interface IProductService
{
    List<Product> GetAllProducts();
    Product? GetProductById(int id);
    List<Product> GetProductsByCategory(string category);
    List<string> GetCategories();
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);
}